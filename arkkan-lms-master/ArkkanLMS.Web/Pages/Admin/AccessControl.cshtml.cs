using ArkkanLMS.Core.Entities;
using ArkkanLMS.Core.Security;
using ArkkanLMS.Core.Types;
using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages.Admin
{
    [Authorize(Policy = "perm:manage_users")]
    public class AccessControlModel : ArkkanLMS.Web.Pages.BasePageModel
    {
        public AccessControlModel(AppDbContext dbContext) : base(dbContext) { }

        [BindProperty(SupportsGet = true)]
        public int? Role { get; set; }

        public UserRoleType SelectedRole { get; private set; }
        public List<SelectListItem> RoleOptions { get; private set; }
        public List<PermissionOption> PermissionOptions { get; private set; }
        public string Toast { get; private set; }
        public string ModeLabel { get; private set; }

        public async Task<IActionResult> OnGetAsync(string toast = null)
        {
            var ok = await LoadCurrentUserAsync();
            if (!ok) return Challenge();

            Toast = toast;
            await LoadAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int role, string[] permissions, string action = null)
        {
            var ok = await LoadCurrentUserAsync();
            if (!ok) return Challenge();

            SelectedRole = (UserRoleType)role;

            if (action == "reset")
            {
                var existing = await DbContext.RolePermissionAssignments.Where(x => x.Role == SelectedRole).ToListAsync();
                if (existing.Count > 0)
                {
                    DbContext.RolePermissionAssignments.RemoveRange(existing);
                    await DbContext.SaveChangesAsync();
                }

                return RedirectToPage(new { role, toast = "Role access reset to defaults." });
            }

            var desired = new HashSet<PermissionType>((permissions ?? new string[0])
                .Select(p => System.Enum.TryParse<PermissionType>(p, out var parsed) ? (PermissionType?)parsed : null)
                .Where(x => x.HasValue)
                .Select(x => x.Value));

            var current = await DbContext.RolePermissionAssignments.Where(x => x.Role == SelectedRole).ToListAsync();
            DbContext.RolePermissionAssignments.RemoveRange(current);

            foreach (var perm in desired)
            {
                DbContext.RolePermissionAssignments.Add(new RolePermissionAssignment
                {
                    Role = SelectedRole,
                    Permission = perm
                });
            }

            await DbContext.SaveChangesAsync();
            return RedirectToPage(new { role, toast = "Access control updated." });
        }

        private async Task LoadAsync()
        {
            var allRoles = System.Enum.GetValues(typeof(UserRoleType)).Cast<UserRoleType>()
                .Distinct()
                .OrderBy(x => (int)x)
                .ToList();

            RoleOptions = allRoles
                .Select(r => new SelectListItem(r.ToString(), ((int)r).ToString()))
                .ToList();

            SelectedRole = Role.HasValue ? (UserRoleType)Role.Value : UserRoleType.Admin;

            var assigned = await DbContext.RolePermissionAssignments
                .AsNoTracking()
                .Where(x => x.Role == SelectedRole)
                .Select(x => x.Permission)
                .ToListAsync();

            var hasAssignments = assigned.Count > 0;
            ModeLabel = hasAssignments ? "(DB overrides enabled)" : "(Defaults)";

            var effective = hasAssignments
                ? assigned.ToHashSet()
                : RolePermissions.Get(SelectedRole).ToHashSet();

            PermissionOptions = System.Enum.GetValues(typeof(PermissionType)).Cast<PermissionType>()
                .OrderBy(x => x.ToString())
                .Select(p => new PermissionOption
                {
                    Key = p.ToString(),
                    Checked = effective.Contains(p),
                    Description = Describe(p)
                })
                .ToList();
        }

        private static string Describe(PermissionType p)
        {
            switch (p)
            {
                case PermissionType.create_course: return "Create new courses, drafts, and course shells.";
                case PermissionType.edit_course: return "Edit course metadata, lessons, and curriculum.";
                case PermissionType.delete_course: return "Remove courses from the catalog (soft-delete where applicable).";
                case PermissionType.publish_course: return "Publish/unpublish courses and make them visible to learners.";
                case PermissionType.view_analytics: return "View analytics dashboards and performance metrics.";
                case PermissionType.manage_users: return "Manage users, roles, and access-control configuration.";
                case PermissionType.manage_payments: return "Manage payments, invoices, refunds, and reconciliation.";
                case PermissionType.approve_trainers: return "Approve trainer onboarding and eligibility.";
                case PermissionType.moderate_comments: return "Moderate course comments, reviews, and reports.";
                default: return "Permission description not set.";
            }
        }

        public class PermissionOption
        {
            public string Key { get; set; }
            public bool Checked { get; set; }
            public string Description { get; set; }
        }
    }
}

