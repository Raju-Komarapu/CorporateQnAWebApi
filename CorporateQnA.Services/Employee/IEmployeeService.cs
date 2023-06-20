using CorporateQnA.Core.Models.Employees.ViewModels;
using CorporateQnA.Data.Models.Employee;

namespace CorporateQnA.Services.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeListItem GetEmployeeById(Guid id);

        IEnumerable<EmployeeListItem> GetAllEmployees();

        void AddEmployee(Employee newEmployee);
    }
}