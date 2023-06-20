using AutoMapper;
using CorporateQnA.Infrastructure.DbContext;

namespace CorporateQnA.Services.Lookup
{
    public class LookupService : ILookupService
    {

        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        public LookupService(ApplicationDbContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public IEnumerable<Core.Models.Department.Department> GetDepartments()
        {
            var departments = this._db.GetAll<Data.Models.Department.Department>();
            return this._mapper.Map<IEnumerable<Core.Models.Department.Department>>(departments);
        }

        public IEnumerable<Core.Models.Designation.Designation> GetDesignations()
        {
            var designations = this._db.GetAll<Data.Models.Designation.Designation>();
            return this._mapper.Map<IEnumerable<Core.Models.Designation.Designation>>(designations);
        }

        public IEnumerable<Core.Models.Location.Location> GetLocations()
        {
            var locations = this._db.GetAll<Data.Models.Location.Location>();
            return this._mapper.Map<IEnumerable<Core.Models.Location.Location>>(locations);
        }
    }
}
