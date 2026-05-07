using ArkkanLMS.Core.Interfaces;
using ArkkanLMS.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArkkanLMS.Core.Entities
{
    public class User : IAuditableEntity
    {
        public User()
        {
            this.Bookings = new HashSet<CourseBooking>();
            this.TrainerSessions = new HashSet<ClassSession>();
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public UserRoleType Role { get; set; }

        public ICollection<CourseBooking> Bookings { get; set; }
        public ICollection<ClassSession> TrainerSessions { get; set; }
    }
}


