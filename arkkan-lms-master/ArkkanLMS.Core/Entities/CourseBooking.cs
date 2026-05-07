using ArkkanLMS.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace ArkkanLMS.Core.Entities
{
    public class CourseBooking : IAuditableEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }

        [Required]
        public int TraineeId { get; set; }
        public User Trainee { get; set; }

        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int? ClassSessionId { get; set; }
        public ClassSession ClassSession { get; set; }

        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
        public DateTime DateBooked { get; set; }
    }
}


