using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages.Trainer
{
    [Authorize(Policy = "perm:create_course")]
    public class CoursesModel : ArkkanLMS.Web.Pages.BasePageModel
    {
        public CoursesModel(AppDbContext dbContext) : base(dbContext) { }
        public async Task<IActionResult> OnGet() { var ok = await LoadCurrentUserAsync(); if (!ok) return Challenge(); return Page(); }
    }
}
