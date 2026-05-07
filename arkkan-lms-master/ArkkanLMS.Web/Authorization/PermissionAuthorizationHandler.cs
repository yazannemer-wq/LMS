using ArkkanLMS.Core.Security;
using ArkkanLMS.Core.Types;
using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArkkanLMS.Web.Authorization
{
    public sealed class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly AppDbContext _dbContext;

        public PermissionAuthorizationHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User?.Identity?.IsAuthenticated != true)
                return;

            // Fast-path: explicit permission claims (useful for UI and overrides)
            if (context.User.Claims.Any(c => c.Type == Permissions.ClaimType && c.Value == requirement.Permission.ToString()))
            {
                context.Succeed(requirement);
                return;
            }

            var userIdValue = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdValue, out var userId))
                return;

            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
                return;

            // If access-control entries exist for the role, they override defaults.
            var hasAnyAssignmentsForRole = await _dbContext.RolePermissionAssignments
                .AsNoTracking()
                .AnyAsync(x => x.Role == user.Role);

            if (hasAnyAssignmentsForRole)
            {
                var allowed = await _dbContext.RolePermissionAssignments
                    .AsNoTracking()
                    .AnyAsync(x => x.Role == user.Role && x.Permission == requirement.Permission);

                if (allowed)
                {
                    context.Succeed(requirement);
                }

                return;
            }

            if (RolePermissions.Has(user.Role, requirement.Permission))
            {
                context.Succeed(requirement);
            }
        }
    }
}

