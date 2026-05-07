using ArkkanLMS.Core.Entities;
using ArkkanLMS.Core.Types;
using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArkkanLMS.Web.Authorization;

namespace ArkkanLMS.Web.Pages.Admin
{
    [Authorize(Policy = "perm:manage_users")]
    public class UsersModel : BasePageModel
    {
        public UsersModel(AppDbContext dbContext) : base(dbContext)
        {
        }

        public List<User> Users { get; set; }
        public List<SelectListItem> RoleOptions { get; set; }
        public bool HasCurrentUser { get; private set; }

        public async Task<IActionResult> OnGetAsync()
        {
            HasCurrentUser = await LoadCurrentUserAsync();
            if (!HasCurrentUser)
            {
                return RedirectToPage("/Account/Login");
            }

            if (!IsCurrentUserRole(UserRoleType.Admin))
            {
                return Forbid();
            }

            await LoadDataAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int userId, int role)
        {
            HasCurrentUser = await LoadCurrentUserAsync();
            if (!HasCurrentUser)
            {
                return RedirectToPage("/Account/Login");
            }

            if (!IsCurrentUserRole(UserRoleType.Admin))
            {
                return Forbid();
            }

            var user = await DbContext.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            user.Role = (UserRoleType)role;
            await DbContext.SaveChangesAsync();
            await LoadDataAsync();
            return Page();
        }

        private async Task LoadDataAsync()
        {
            Users = await DbContext.Users.AsNoTracking().ToListAsync();
            RoleOptions = System.Enum.GetValues(typeof(UserRoleType))
                .Cast<UserRoleType>()
                .Select(role => new SelectListItem(role.ToString(), ((int)role).ToString()))
                .ToList();
        }
    }
}


