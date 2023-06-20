using AutoMapper;

namespace CorporateQnA.Core.Models.Profiles
{
    public class LookupMappingProfile : Profile
    {
        public LookupMappingProfile()
        {
            CreateMap<Data.Models.Department.Department, Core.Models.Department.Department>().ReverseMap();

            CreateMap<Data.Models.Designation.Designation, Core.Models.Designation.Designation>().ReverseMap();

            CreateMap<Data.Models.Location.Location, Core.Models.Location.Location>().ReverseMap();
        }
    }
}
