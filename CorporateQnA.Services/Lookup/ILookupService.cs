using CorporateQnA.Core.Models.Department;
using CorporateQnA.Core.Models.Designation;
using CorporateQnA.Core.Models.Location;

namespace CorporateQnA.Services.Lookup
{
    public interface ILookupService
    {
        IEnumerable<Location> GetLocations();

        IEnumerable<Department> GetDepartments();

        IEnumerable<Designation> GetDesignations();
    }
}
