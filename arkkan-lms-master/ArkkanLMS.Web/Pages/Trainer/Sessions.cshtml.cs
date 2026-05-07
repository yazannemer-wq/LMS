using ArkkanLMS.Core.Entities;
using ArkkanLMS.Core.Types;
using ArkkanLMS.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages.Trainer
{
    [Authorize(Roles = "Trainer")]
    public class SessionsModel : BasePageModel
    {
        public SessionsModel(AppDbContext dbContext) : base(dbContext)
        {
            NewSession = new NewSessionModel();
        }

        [BindProperty]
        public NewSessionModel NewSession { get; set; }

        public List<SelectListItem> CourseItems { get; set; }
        public List<ClassSession> Sessions { get; set; }
        public bool HasCurrentUser { get; private set; }

        public async Task<IActionResult> OnGetAsync()
        {
            HasCurrentUser = await LoadCurrentUserAsync();
            if (!HasCurrentUser)
            {
                return RedirectToPage("/Account/Login");
            }

            if (!IsCurrentUserRole(UserRoleType.Trainer))
            {
                return Forbid();
            }

            await LoadSessionDataAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            HasCurrentUser = await LoadCurrentUserAsync();
            if (!HasCurrentUser)
            {
                return RedirectToPage("/Account/Login");
            }

            if (!IsCurrentUserRole(UserRoleType.Trainer))
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                await LoadSessionDataAsync();
                return Page();
            }

            var session = new ClassSession
            {
                Title = NewSession.Title,
                CourseId = NewSession.CourseId,
                TrainerId = CurrentUser.Id,
                StartTime = NewSession.StartTime,
                EndTime = NewSession.EndTime,
                IsOpen = true
            };

            DbContext.ClassSessions.Add(session);
            await DbContext.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostToggleAsync(int sessionId, bool isOpen)
        {
            HasCurrentUser = await LoadCurrentUserAsync();
            if (!HasCurrentUser)
            {
                return RedirectToPage("/Account/Login");
            }

            if (!IsCurrentUserRole(UserRoleType.Trainer))
            {
                return Forbid();
            }

            var session = await DbContext.ClassSessions.FindAsync(sessionId);
            if (session == null || session.TrainerId != CurrentUser.Id)
            {
                return NotFound();
            }

            session.IsOpen = isOpen;
            await DbContext.SaveChangesAsync();

            return RedirectToPage();
        }

        private async Task LoadSessionDataAsync()
        {
            CourseItems = await DbContext.Courses.AsNoTracking()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToListAsync();

            Sessions = await DbContext.ClassSessions
                .Include(x => x.Course)
                .Where(x => x.TrainerId == CurrentUser.Id)
                .AsNoTracking()
                .ToListAsync();
        }

        public class NewSessionModel
        {
            [Required]
            public string Title { get; set; }

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Please select a course.")]
            public int CourseId { get; set; }

            [Required]
            public DateTime StartTime { get; set; }

            [Required]
            public DateTime EndTime { get; set; }
        }
    }
}


