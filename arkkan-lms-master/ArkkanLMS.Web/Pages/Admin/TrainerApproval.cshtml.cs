using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ArkkanLMS.Web.Authorization;

namespace ArkkanLMS.Web.Pages.Admin
{
    [Authorize(Policy = "perm:approve_trainers")]
    public class TrainerApprovalModel : ArkkanLMS.Web.Pages.BasePageModel
    {
        public TrainerApprovalModel(AppDbContext dbContext) : base(dbContext) { }

        public async Task<IActionResult> OnGet()
        {
            var ok = await LoadCurrentUserAsync();
            if (!ok) return Challenge();
            return Page();
        }
    }
}

