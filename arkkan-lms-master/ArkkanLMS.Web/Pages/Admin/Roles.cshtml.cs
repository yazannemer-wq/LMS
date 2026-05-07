using ArkkanLMS.Core.Security;
using ArkkanLMS.Core.Types;
using ArkkanLMS.Persistence;
using ArkkanLMS.Web.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages.Admin
{
    [Authorize(Policy = "perm:manage_users")]
    public class RolesModel : ArkkanLMS.Web.Pages.BasePageModel
    {
        public RolesModel(AppDbContext dbContext) : base(dbContext) { }

        public List<RoleRow> Roles { get; private set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var ok = await LoadCurrentUserAsync();
            if (!ok) return Challenge();

            var allRoles = System.Enum.GetValues(typeof(UserRoleType)).Cast<UserRoleType>()
                .Distinct()
                .OrderBy(x => (int)x)
                .ToList();

            var dbCounts = await DbContext.RolePermissionAssignments
                .AsNoTracking()
                .GroupBy(x => x.Role)
                .Select(g => new { Role = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Role, x => x.Count);

            Roles = allRoles.Select(r =>
            {
                var count = dbCounts.TryGetValue(r, out var c) ? c : RolePermissions.Get(r).Count();
                return new RoleRow { Role = r, PermissionCount = count };
            }).ToList();

            return Page();
        }

        public class RoleRow
        {
            public UserRoleType Role { get; set; }
            public int PermissionCount { get; set; }
        }
    }
}

