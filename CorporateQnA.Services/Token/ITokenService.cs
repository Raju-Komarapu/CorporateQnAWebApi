using Microsoft.AspNetCore.Identity;

namespace CorporateQnA.Services.Token
{
    public interface ITokenService
    {
        string GenerateToken(IdentityUser user);
    }
}
