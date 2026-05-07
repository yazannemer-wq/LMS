using ArkkanLMS.Core.Entities;
using ArkkanLMS.Core.Types;
using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages.Courses
{
    public class DetailsModel : BasePageModel
    {
        public DetailsModel(AppDbContext dbContext) : base(dbContext)
        {
        }

        public Course Course { get; private set; }
        public List<ClassSession> OpenSessions { get; private set; } = new List<ClassSession>();
        public bool HasCurrentUser { get; private set; }
        public bool IsTrainee => HasCurrentUser && IsCurrentUserRole(UserRoleType.Trainee);

        public async Task<IActionResult> OnGetAsync(int id)
        {
            HasCurrentUser = await LoadCurrentUserAsync();

            Course = await DbContext.Courses
                .AsNoTracking()
                .Include(c => c.CourseLessons)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (Course == null)
            {
                return NotFound();
            }

            OpenSessions = await DbContext.ClassSessions
                .AsNoTracking()
                .Where(s => s.CourseId == id && s.IsOpen)
                .ToListAsync();

            return Page();
        }
    }
}

