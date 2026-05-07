using ArkkanLMS.Core.Types;

namespace ArkkanLMS.Web.Authorization
{
    public static class Permissions
    {
        public const string ClaimType = "perm";

        public static string Policy(PermissionType permission) => $"perm:{permission}";
    }
}

