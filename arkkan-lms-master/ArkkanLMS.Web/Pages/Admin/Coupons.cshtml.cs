using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class CouponsModel : ArkkanLMS.Web.Pages.BasePageModel
    {
        public CouponsModel(AppDbContext dbContext) : base(dbContext) { }

        public async Task<IActionResult> OnGet()
        {
            var ok = await LoadCurrentUserAsync();
            if (!ok) return Challenge();
            return Page();
        }
    }
}

