using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages.Finance
{
    [Authorize(Policy = "perm:view_analytics")]
    public class AnalyticsModel : ArkkanLMS.Web.Pages.BasePageModel
    {
        public AnalyticsModel(AppDbContext dbContext) : base(dbContext) { }

        public async Task<IActionResult> OnGet()
        {
            var ok = await LoadCurrentUserAsync();
            if (!ok) return Challenge();
            return Page();
        }
    }
}

