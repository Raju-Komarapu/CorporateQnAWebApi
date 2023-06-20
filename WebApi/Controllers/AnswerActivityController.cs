using CorporateQnA.Core.Models.EmployeeActivities;
using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/answeractivity")]
    public class AnswerActivityController : BaseController
    {
        private readonly IAnswerService _answerServices;

        public AnswerActivityController(IAnswerService answerServices)
        {
            this._answerServices = answerServices;
        }

        [HttpPut]
        public void UpdateAnswerActivity(EmployeeAnswerActivity newActivity)
        {
            this._answerServices.UpdateAnswerActivity(newActivity);
        }
    }
}
