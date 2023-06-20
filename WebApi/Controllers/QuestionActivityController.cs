using CorporateQnA.Core.Models.EmployeeActivities;
using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/questionactivity")]
    public class QuestionActivityController : BaseController
    {
        private readonly IQuestionService _questionServices;

        public QuestionActivityController(IQuestionService questionServices)
        {
            this._questionServices = questionServices;
        }

        [HttpPost]
        public int AddQuestionActivity(EmployeeQuestionActivity newActivity)
        {
            return this._questionServices.AddQuestionActivity(newActivity);
        }

        [HttpPut]
        public void UpdateQuestionActivity(EmployeeQuestionActivity newActivity)
        {
            this._questionServices.UpdateQuestionActivity(newActivity);
        }
    }
}
