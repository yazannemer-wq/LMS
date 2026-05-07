using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages.Dashboard
{
    [Authorize(Roles = "Trainee")]
    public class IndexModel : ArkkanLMS.Web.Pages.BasePageModel
    {
        public IndexModel(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IActionResult> OnGet()
        {
            var ok = await LoadCurrentUserAsync();
            if (!ok) return Challenge();
            return Page();
        }
    }
}

