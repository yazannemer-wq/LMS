using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ArkkanLMS.Core.Entities;
using ArkkanLMS.Core.Interfaces;
using ArkkanLMS.Core.DataTransferObjects;

namespace ArkkanLMS.Web.Areas.Admin.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ICourseService courseService;

        public CreateModel(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateCourseDto CourseDto { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await courseService.AddCourseAsync(CourseDto);

            return RedirectToPage("./Index");
        }
    }
}


