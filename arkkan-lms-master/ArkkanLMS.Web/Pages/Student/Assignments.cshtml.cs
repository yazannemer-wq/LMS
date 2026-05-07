using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages.Student
{
    [Authorize(Roles = "Trainee,Admin,Trainer")]
    public class AssignmentsModel : ArkkanLMS.Web.Pages.BasePageModel
    {
        public AssignmentsModel(AppDbContext dbContext) : base(dbContext) { }
        public async Task<IActionResult> OnGet()
        {
            var ok = await LoadCurrentUserAsync();
            if (!ok) return Challenge();
            return Page();
        }
    }
}
