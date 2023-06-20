using CorporateQnA.Core.Models.Questions;
using CorporateQnA.Core.Models.Questions.ViewModels;
using CorporateQnA.Core.Models.Report;
using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/question")]
    public class QuestionController : BaseController
    {
        private readonly IQuestionService _questionServices;

        public QuestionController(IQuestionService questionServices)
        {
            this._questionServices = questionServices;
        }

        [HttpPost]
        public Guid AddQuestion(Question newQuestion)
        {
            return this._questionServices.AddQuestion(newQuestion);
        }

        [HttpPost("report")]
        public void Report(Report report)
        {
            this._questionServices.ReportQuestion(report);
        }

        [HttpGet("all")]
        public IEnumerable<QuestionListItem> GetAllQuestions()
        {
            return this._questionServices.GetAllQuestions();
        }

        [HttpGet("{id}")]
        public QuestionListItem GetQuestion(Guid id)
        {
            return this._questionServices.GetQuestionById(id);
        }

        [HttpGet("asked/{employeeId}")]
        public IEnumerable<QuestionListItem> GetQuestionsAskedByEmployeeId(Guid employeeId)
        {
            return this._questionServices.GetQuestionsAskedByEmployee(employeeId);
        }

        [HttpGet("answered/{employeeId}")]
        public IEnumerable<QuestionListItem> GetQuestionsAnsweredByEmployeeId(Guid employeeId)
        {
            return this._questionServices.GetQuestionsAnsweredByEmployee(employeeId);
        }
    }
}
