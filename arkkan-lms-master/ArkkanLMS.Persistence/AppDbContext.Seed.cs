using ArkkanLMS.Core.Entities;
using ArkkanLMS.Core.Types;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ArkkanLMS.Persistence
{
    public partial class AppDbContext
    {
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public void SeedData()
        {
            SeedUserIfMissing("Ahmad Admin", "admin@ArkkanLMS.dev", "admin123", UserRoleType.Admin);
            SeedUserIfMissing("Ali Trainer", "trainer@ArkkanLMS.dev", "trainer123", UserRoleType.Trainer);
            SeedUserIfMissing("Tina Trainee", "trainee@ArkkanLMS.dev", "trainee123", UserRoleType.Trainee);
            SeedUserIfMissing("Mona Moderator", "moderator@ArkkanLMS.dev", "moderator123", UserRoleType.Moderator);
            SeedUserIfMissing("Sam Support", "support@ArkkanLMS.dev", "support123", UserRoleType.Support);
            SeedUserIfMissing("Fadi Finance", "finance@ArkkanLMS.dev", "finance123", UserRoleType.Finance);

            if (!this.Courses.Any())
            {
                this.Courses.AddRange(
                    new Course { Name = "Fundamentals of Online Learning", Description = "A starter course for trainees and trainers.", CourseType = CourseType.LiveWebinar, CourseImageURL = "https://placehold.co/600x200?text=Online+Learning" },
                    new Course { Name = "Trainer Workshop", Description = "Skills for planning, opening, and closing sessions.", CourseType = CourseType.OnDemandSimple, CourseImageURL = "https://placehold.co/600x200?text=Trainer+Workshop" }
                );
                this.SaveChanges();
            }

            if (!this.ClassSessions.Any())
            {
                var trainer = this.Users.FirstOrDefault(u => u.Role == UserRoleType.Trainer);
                var course = this.Courses.FirstOrDefault();
                if (trainer != null && course != null)
                {
                    this.ClassSessions.Add(
                        new ClassSession
                        {
                            Title = "Morning Online Session",
                            CourseId = course.Id,
                            TrainerId = trainer.Id,
                            StartTime = DateTime.UtcNow.AddDays(1).AddHours(9),
                            EndTime = DateTime.UtcNow.AddDays(1).AddHours(11),
                            IsOpen = true
                        }
                    );
                    this.SaveChanges();
                }
            }
        }

        private void SeedUserIfMissing(string name, string email, string password, UserRoleType role)
        {
            var exists = this.Users.Any(u => u.Email == email);
            if (exists) return;

            this.Users.Add(new User
            {
                Name = name,
                Email = email,
                PasswordHash = HashPassword(password),
                Role = role
            });

            this.SaveChanges();
        }
    }
}


