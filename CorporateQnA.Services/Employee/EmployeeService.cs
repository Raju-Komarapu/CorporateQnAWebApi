using AutoMapper;
using CorporateQnA.Core.Models.Employees.ViewModels;
using CorporateQnA.Data.Models.Employee;
using CorporateQnA.Data.Models.Employee.Views;
using CorporateQnA.Infrastructure.DbContext;
using CorporateQnA.Services.Interfaces;

namespace CorporateQnA.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        public EmployeeService(ApplicationDbContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public EmployeeListItem GetEmployeeById(Guid id)
        {
            var employee = this._db.Get<EmployeeDetailsView>(id);
            return this._mapper.Map<EmployeeListItem>(employee);
        }

        public IEnumerable<EmployeeListItem> GetAllEmployees()
        {
            var employeeList = this._db.GetAll<EmployeeDetailsView>();
            return this._mapper.Map<IEnumerable<EmployeeListItem>>(employeeList);
        }

        public void AddEmployee(Employee newEmployee)
        {
            this._db.Insert(newEmployee);
        }
    }
}