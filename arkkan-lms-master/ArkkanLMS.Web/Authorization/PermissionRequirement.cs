using ArkkanLMS.Core.Types;
using Microsoft.AspNetCore.Authorization;

namespace ArkkanLMS.Web.Authorization
{
    public sealed class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionType Permission { get; }

        public PermissionRequirement(PermissionType permission)
        {
            Permission = permission;
        }
    }
}

