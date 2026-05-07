namespace ArkkanLMS.Core.Types
{
    public enum UserRoleType
    {
        Admin = 1,
        Trainer = 2,
        Trainee = 3,
        // Alias for Trainee (kept to preserve existing "Trainee" role string usage)
        Student = 3,
        Moderator = 4,
        Support = 5,
        Finance = 6
    }
}


