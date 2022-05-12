using Api.Models;

namespace Api.Services.Interfaces
{
    public interface IAuthService
    {
        string GetAuthenticationToken(WebUser webUser);

        bool RegisterNewUser(WebUser webUser);
    }
}