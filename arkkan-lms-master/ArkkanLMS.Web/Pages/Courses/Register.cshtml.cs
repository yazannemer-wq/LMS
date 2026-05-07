using ArkkanLMS.Core.Entities;
using ArkkanLMS.Core.Types;
using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages.Courses
{
    public class RegisterModel : BasePageModel
    {
        public RegisterModel(AppDbContext dbContext) : base(dbContext)
        {
        }

        [BindProperty]
        public int CourseId { get; set; }

        [BindProperty]
        public int? SelectedSessionId { get; set; }

        public Course Course { get; set; }
        public List<ClassSession> Sessions { get; set; }
        public decimal Price { get; set; } = 49.99m;

        public bool HasCurrentUser { get; private set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            HasCurrentUser = await LoadCurrentUserAsync();

            if (!HasCurrentUser)
            {
                return RedirectToPage("/Account/Login");
            }

            if (!IsCurrentUserRole(UserRoleType.Trainee))
            {
                return Forbid();
            }

            Course = await DbContext.Courses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (Course == null)
            {
                return NotFound();
            }

            CourseId = Course.Id;
            Sessions = await DbContext.ClassSessions.AsNoTracking()
                .Where(x => x.CourseId == id && x.IsOpen)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            HasCurrentUser = await LoadCurrentUserAsync();
            if (!HasCurrentUser)
            {
                return RedirectToPage("/Account/Login");
            }

            if (!IsCurrentUserRole(UserRoleType.Trainee))
            {
                return Forbid();
            }

            Course = await DbContext.Courses.FirstOrDefaultAsync(x => x.Id == CourseId);
            if (Course == null)
            {
                return NotFound();
            }

            var booking = new CourseBooking
            {
                TraineeId = CurrentUser.Id,
                CourseId = CourseId,
                ClassSessionId = SelectedSessionId,
                Price = Price,
                IsPaid = false,
                DateBooked = DateTime.UtcNow
            };

            DbContext.CourseBookings.Add(booking);
            await DbContext.SaveChangesAsync();

            return RedirectToPage("/Bookings/Index");
        }
    }
}


