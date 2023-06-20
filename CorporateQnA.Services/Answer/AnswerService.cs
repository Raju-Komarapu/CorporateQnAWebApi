using AutoMapper;
using CorporateQnA.Core.Models.Answers;
using CorporateQnA.Core.Models.Answers.ViewModels;
using CorporateQnA.Core.Models.EmployeeActivities;
using CorporateQnA.Data.Models.Answer.Views;
using CorporateQnA.Infrastructure.DbContext;
using CorporateQnA.Services.Interfaces;
using CorporateQnA.Services.RequestContext;

namespace CorporateQnA.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        private readonly IRequestContext _requestContext;

        public AnswerService(ApplicationDbContext db, IMapper mapper, IRequestContext requestContext)
        {
            this._db = db;
            this._mapper = mapper;
            this._requestContext = requestContext;
        }

        public IEnumerable<AnswerListItem> GetAnswersByQuestionId(Guid questionId)
        {
            var sqlQuery = "SELECT * FROM AnswerDetailsView WHERE QuestionId = @questionId AND CurrentEmployeeId = @currentEmployeeId";
            var parameters = new { questionId = questionId, currentEmployeeId = this._requestContext.Id };
            var answers = this._db.Query<AnswerDetailsView>(sqlQuery, parameters);
            return this._mapper.Map<IEnumerable<AnswerListItem>>(answers);
        }

        public Guid AddAnswer(Answer newAnswer)
        {
            var answer = this._mapper.Map<Data.Models.Answer.Answer>(newAnswer);
            var sqlQuery = "INSERT INTO Answer (QuestionId, Description, AnsweredBy, AnsweredOn) OUTPUT INSERTED.Id VALUES (@questionId, @description, @answeredBy, @answeredOn)";
            var parameters = new { questionId = answer.QuestionId, description = answer.Description, answeredBy = answer.AnsweredBy, answeredOn = answer.AnsweredOn };
            return this._db.ExecuteScalar<Guid>(sqlQuery, parameters);
        }

        public void UpdateAnswerActivity(EmployeeAnswerActivity newActivity)
        {
            var sqlQuery = "SELECT * FROM EmployeeAnswerActivity WHERE EmployeeId = @employeeId AND AnswerId = @answerId";
            var parameters = new { employeeId = newActivity.EmployeeId, answerId = newActivity.AnswerId };
            var existingActivity = this._db.QuerySingleOrDefault<Data.Models.EmployeeActivities.EmployeeAnswerActivity>(sqlQuery, parameters);

            if (existingActivity != null)
            {
                existingActivity.VoteStatus = newActivity.VoteStatus;
                this._db.Update(existingActivity);
            }
            else
            {
                var activity = this._mapper.Map<Data.Models.EmployeeActivities.EmployeeAnswerActivity>(newActivity);
                this._db.Insert(activity);
            }
        }

        public void UpdateBestSolution(Guid answerId)
        {
            var answer = this._db.Get<Data.Models.Answer.Answer>(answerId);
            answer.IsBestSolution = !answer.IsBestSolution;
            this._db.Update(answer);
        }

        public AnswerListItem GetAnswer(Guid id)
        {
            var answer = this._db.Get<AnswerDetailsView>(id);
            return this._mapper.Map<AnswerListItem>(answer);
        }
    }
}
