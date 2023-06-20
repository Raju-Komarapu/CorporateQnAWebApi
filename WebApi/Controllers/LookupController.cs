using CorporateQnA.Core.Models.Enum;
using CorporateQnA.Services.Lookup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/lookup")]
    public class LookupController : BaseController
    {
        private readonly ILookupService _lookupService;
        public LookupController(ILookupService lookupService)
        {
            this._lookupService = lookupService;
        }

        [HttpGet("{resource}")]
        [AllowAnonymous]
        public IEnumerable<object> GetResource(LookupEnum resource)
        {
            switch (resource)
            {
                case LookupEnum.Location:
                    return this._lookupService.GetLocations();
                case LookupEnum.Department:
                    return this._lookupService.GetDepartments();

                case LookupEnum.Designation:
                    return this._lookupService.GetDesignations();

                default:
                    return Enumerable.Empty<object>();
            }
        }
    }
}
