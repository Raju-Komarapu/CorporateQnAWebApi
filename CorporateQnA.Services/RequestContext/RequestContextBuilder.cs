using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace CorporateQnA.Services.RequestContext
{
    public class RequestContextBuilder
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestContextBuilder(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IRequestContext Build()
        {
            var requestContext = new AppRequestContext();
            var employeeId = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(c => c.Type == "UserId")?.Value;
            requestContext.Id = Guid.Parse(employeeId);
            return requestContext;
        }
    }

}
