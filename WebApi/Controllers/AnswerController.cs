using CorporateQnA.Core.Models.Answers;
using CorporateQnA.Core.Models.Answers.ViewModels;
using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace CorporateQnA.Api.Controllers
{
    [Route("api/answer")]
    public class AnswerController : BaseController
    {
        private readonly IAnswerService _answerServices;

        public AnswerController(IAnswerService answerServices)
        {
            this._answerServices = answerServices;
        }

        [HttpPost]
        public Guid AddAnswer(Answer newAnswer)
        {
            return this._answerServices.AddAnswer(newAnswer);
        }

        [HttpGet("{id}")]
        public AnswerListItem GetAnswer(Guid id)
        {
            return this._answerServices.GetAnswer(id);
        }

        [HttpGet("all/{questionId}")]
        public IEnumerable<AnswerListItem> GetAnswersByQuestionId(Guid questionId)
        {
            return this._answerServices.GetAnswersByQuestionId(questionId); ;
        }

        [HttpPut("updatebestsolution")]
        public void UpdateBestSolution(Guid answerId)
        {
            this._answerServices.UpdateBestSolution(answerId);
        }
    }
}

