using AutoMapper;
using CorporateQnA.Core.Models.Authentication;
using CorporateQnA.Core.Models.Employees.ViewModels;
using CorporateQnA.Data.Models.Employee;
using CorporateQnA.Data.Models.Employee.Views;

namespace CorporateQnA.Core.Models.Profiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<EmployeeDetailsView, EmployeeListItem>().ReverseMap();

            CreateMap<Core.Models.EmployeeActivities.EmployeeQuestionActivity, Data.Models.EmployeeActivities.EmployeeQuestionActivity>().ReverseMap();

            CreateMap<Core.Models.EmployeeActivities.EmployeeAnswerActivity, Data.Models.EmployeeActivities.EmployeeAnswerActivity>().ReverseMap();

            CreateMap<RegisterModel, Employee>().ReverseMap();
        }
    }
}