using ArkkanLMS.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArkkanLMS.Core.Security
{
    public static class RolePermissions
    {
        private static readonly IReadOnlyDictionary<UserRoleType, HashSet<PermissionType>> _map =
            new Dictionary<UserRoleType, HashSet<PermissionType>>
            {
                [UserRoleType.Admin] = Enum.GetValues(typeof(PermissionType)).Cast<PermissionType>().ToHashSet(),

                [UserRoleType.Trainer] = new HashSet<PermissionType>
                {
                    PermissionType.create_course,
                    PermissionType.edit_course,
                    PermissionType.publish_course,
                    PermissionType.view_analytics
                },

                [UserRoleType.Trainee] = new HashSet<PermissionType>
                {
                    // Intentionally empty for now (trainee capabilities are handled by dedicated pages)
                },

                [UserRoleType.Moderator] = new HashSet<PermissionType>
                {
                    PermissionType.moderate_comments
                },

                [UserRoleType.Support] = new HashSet<PermissionType>
                {
                    PermissionType.manage_users,
                    PermissionType.approve_trainers
                },

                [UserRoleType.Finance] = new HashSet<PermissionType>
                {
                    PermissionType.manage_payments,
                    PermissionType.view_analytics
                }
            };

        public static bool Has(UserRoleType role, PermissionType permission)
        {
            if (role == UserRoleType.Admin) return true;
            return _map.TryGetValue(role, out var perms) && perms.Contains(permission);
        }

        public static IEnumerable<PermissionType> Get(UserRoleType role)
        {
            if (role == UserRoleType.Admin)
                return Enum.GetValues(typeof(PermissionType)).Cast<PermissionType>();

            return _map.TryGetValue(role, out var perms) ? perms : Enumerable.Empty<PermissionType>();
        }
    }
}

