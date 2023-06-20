using CorporateQnA.Core.Models.Authentication;

namespace CorporateQnA.Services.Authentication
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(LoginModel model);

        Task<AuthResponse> Register(RegisterModel model);
    }
}
