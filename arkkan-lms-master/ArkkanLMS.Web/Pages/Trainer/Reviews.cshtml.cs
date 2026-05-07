using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages.Trainer
{
    [Authorize(Roles = "Trainer,Admin")]
    public class ReviewsModel : ArkkanLMS.Web.Pages.BasePageModel
    {
        public ReviewsModel(AppDbContext dbContext) : base(dbContext) { }
        public async Task<IActionResult> OnGet() { var ok = await LoadCurrentUserAsync(); if (!ok) return Challenge(); return Page(); }
    }
}
