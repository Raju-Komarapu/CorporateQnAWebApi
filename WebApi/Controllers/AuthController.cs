using CorporateQnA.Core.Models.Authentication;
using CorporateQnA.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/auth")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        private readonly IWebHostEnvironment _env;

        public AuthController(IAuthService authService, IWebHostEnvironment env)
        {
            this._authService = authService;
            this._env = env;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<AuthResponse> Register(RegisterModel model)
        {
            return await this._authService.Register(model);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<AuthResponse> Login(LoginModel model)
        {
            return await this._authService.Login(model);
        }
    }
}
