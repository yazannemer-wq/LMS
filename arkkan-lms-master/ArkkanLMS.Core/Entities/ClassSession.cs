using ArkkanLMS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArkkanLMS.Core.Entities
{
    public class ClassSession : IAuditableEntity
    {
        public ClassSession()
        {
            this.Bookings = new HashSet<CourseBooking>();
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Required]
        public int TrainerId { get; set; }
        public User Trainer { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public bool IsOpen { get; set; }
        public ICollection<CourseBooking> Bookings { get; set; }
    }
}


