using System;
using System.Threading.Tasks;
using usos.API.Application.Models.Auth;

namespace usos.API.Application.IServices.Auth
{
    public interface IAuthService
    {
        Task<(string userId, string email, string roleId)> Login(LoginRequest request);

        Task SetPassword(Guid userId, string token, SetPasswordRequest request);

        Task<CurrentUserResponse> GetCurrentUser();
    }
}