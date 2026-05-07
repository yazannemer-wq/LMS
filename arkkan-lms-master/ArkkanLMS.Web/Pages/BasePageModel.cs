using ArkkanLMS.Core.Entities;
using ArkkanLMS.Core.Types;
using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages
{
    public class BasePageModel : PageModel
    {
        protected readonly AppDbContext DbContext;

        public BasePageModel(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public User CurrentUser { get; private set; }

        public async Task<bool> LoadCurrentUserAsync()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                var userIdValue = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (int.TryParse(userIdValue, out int userId))
                {
                    CurrentUser = await DbContext.Users.FindAsync(userId);
                    return CurrentUser != null;
                }
            }

            return false;
        }

        public bool IsCurrentUserRole(UserRoleType role) => CurrentUser != null && CurrentUser.Role == role;
    }
}


