using ArkkanLMS.Core.Entities;
using ArkkanLMS.Core.Types;
using System.Threading.Tasks;

namespace ArkkanLMS.Core.Interfaces
{
    public interface IAuthenticationService
    {
        Task<User> AuthenticateAsync(string email, string password);
    }
}

