using ArkkanLMS.Core.Types;
using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages.Admin
{
    [Authorize(Policy = "perm:manage_users")]
    public class PermissionsModel : ArkkanLMS.Web.Pages.BasePageModel
    {
        public PermissionsModel(AppDbContext dbContext) : base(dbContext) { }

        public List<PermissionRow> Permissions { get; private set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var ok = await LoadCurrentUserAsync();
            if (!ok) return Challenge();

            Permissions = System.Enum.GetValues(typeof(PermissionType)).Cast<PermissionType>()
                .Select(p => new PermissionRow
                {
                    Key = p.ToString(),
                    Description = Describe(p)
                })
                .OrderBy(x => x.Key)
                .ToList();

            return Page();
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

        public class PermissionRow
        {
            public string Key { get; set; }
            public string Description { get; set; }
        }
    }
}

