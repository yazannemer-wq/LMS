using ArkkanLMS.Core.Interfaces;
using ArkkanLMS.Core.Types;
using System;
using System.ComponentModel.DataAnnotations;

namespace ArkkanLMS.Core.Entities
{
    public class RolePermissionAssignment : IAuditableEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }

        [Required]
        public UserRoleType Role { get; set; }

        [Required]
        public PermissionType Permission { get; set; }
    }
}

