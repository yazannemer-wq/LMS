using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ArkkanLMS.Web.Authorization;

namespace ArkkanLMS.Web.Pages.Admin
{
    [Authorize(Policy = "perm:view_analytics")]
    public class RevenueAnalyticsModel : ArkkanLMS.Web.Pages.BasePageModel
    {
        public RevenueAnalyticsModel(AppDbContext dbContext) : base(dbContext) { }

        public async Task<IActionResult> OnGet()
        {
            var ok = await LoadCurrentUserAsync();
            if (!ok) return Challenge();
            return Page();
        }
    }
}

