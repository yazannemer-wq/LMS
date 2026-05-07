using ArkkanLMS.Core.Entities;
using ArkkanLMS.Core.Types;
using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages.Bookings
{
    [Authorize(Roles = "Trainee")]
    public class IndexModel : BasePageModel
    {
        public IndexModel(AppDbContext dbContext) : base(dbContext)
        {
        }

        public List<CourseBooking> Bookings { get; set; }
        public bool HasCurrentUser { get; private set; }

        public async Task<IActionResult> OnGetAsync()
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

            Bookings = await DbContext.CourseBookings
                .Include(x => x.Course)
                .Include(x => x.ClassSession)
                .Where(x => x.TraineeId == CurrentUser.Id)
                .AsNoTracking()
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int bookingId)
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

            var booking = await DbContext.CourseBookings.FindAsync(bookingId);
            if (booking == null || booking.TraineeId != CurrentUser.Id)
            {
                return NotFound();
            }

            booking.IsPaid = true;
            await DbContext.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}


