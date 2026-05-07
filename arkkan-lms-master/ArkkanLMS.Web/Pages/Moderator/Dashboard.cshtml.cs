using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages.Moderator
{
    [Authorize(Policy = "perm:moderate_comments")]
    public class DashboardModel : ArkkanLMS.Web.Pages.BasePageModel
    {
        public DashboardModel(AppDbContext dbContext) : base(dbContext) { }

        public async Task<IActionResult> OnGet()
        {
            var ok = await LoadCurrentUserAsync();
            if (!ok) return Challenge();
            return Page();
        }
    }
}

