using CorporateQnA.Core.Models.Employees.ViewModels;
using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/employee")]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeServices;

        public EmployeeController(IEmployeeService employeeServices)
        {
            this._employeeServices = employeeServices;
        }

        [HttpGet("all")]
        public IEnumerable<EmployeeListItem> GetAllEmployees()
        {
            return this._employeeServices.GetAllEmployees();
        }

        [HttpGet("{id}")]
        public EmployeeListItem GetEmployeeById(Guid id)
        {
            return this._employeeServices.GetEmployeeById(id);
        }
    }
}
