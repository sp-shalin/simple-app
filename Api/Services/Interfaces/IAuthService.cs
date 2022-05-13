using Api.Models;

namespace Api.Services.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// get authentication token
        /// </summary>
        /// <param name="webUser">web user</param>
        /// <returns>authentication token or null</returns>
        string GetAuthenticationToken(WebUser webUser);

        /// <summary>
        /// register new user and get token
        /// </summary>
        /// <param name="webUser">web user</param>
        /// <returns>authentication token on success</returns>
        string RegisterNewUser(WebUser webUser);
    }
}