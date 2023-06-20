using AutoMapper;
using CorporateQnA.Core.Models.EmployeeActivities;
using CorporateQnA.Core.Models.Questions;
using CorporateQnA.Core.Models.Questions.ViewModels;
using CorporateQnA.Core.Models.Report;
using CorporateQnA.Data.Models.Question.Views;
using CorporateQnA.Infrastructure.DbContext;
using CorporateQnA.Services.Interfaces;
using CorporateQnA.Services.RequestContext;

namespace CorporateQnA.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        private readonly IRequestContext _requestContext;

        public QuestionService(ApplicationDbContext db, IMapper mapper, IRequestContext requestContext)
        {
            this._db = db;
            this._mapper = mapper;
            this._requestContext = requestContext;
        }

        public Guid AddQuestion(Question newQuestion)
        {
            var question = this._mapper.Map<Data.Models.Question.Question>(newQuestion);
            var query = "INSERT INTO Question (Title , Description, CategoryId, CreatedBy, CreatedOn) OUTPUT INSERTED.Id VALUES (@title , @description, @categoryId, @createdBy, @createdOn)";
            return this._db.ExecuteScalar<Guid>(query, new { title = question.Title, description = question.Description, categoryId = question.CategoryId, createdBy = question.CreatedBy, createdOn = question.CreatedOn });
        }

        public QuestionListItem GetQuestionById(Guid questionId)
        {
            var sqlQuery = "SELECT * FROM QuestionDetailsView WHERE Id = @questionId AND CurrentEmployeeId = @currentEmployeeId";
            var parameters = new { questionId = questionId, currentEmployeeId = this._requestContext.Id };
            var question = this._db.QuerySingleOrDefault<QuestionDetailsView>(sqlQuery, parameters);
            return this._mapper.Map<QuestionListItem>(question);
        }

        public IEnumerable<QuestionListItem> GetAllQuestions()
        {
            var sqlQuery = "SELECT * FROM QuestionDetailsView WHERE CurrentEmployeeId = @currentEmployeeId";
            var questions = this._db.Query<QuestionDetailsView>(sqlQuery, new { currentEmployeeId = this._requestContext.Id });
            return this._mapper.Map<IEnumerable<QuestionListItem>>(questions);
        }

        public IEnumerable<QuestionListItem> GetQuestionsAskedByEmployee(Guid employeeId)
        {
            var sqlQuery = "SELECT * FROM QuestionDetailsView WHERE EmployeeId = @employeeId AND CurrentEmployeeId = @currentEmployeeId";
            var parameters = new { employeeId = employeeId, currentEmployeeId = this._requestContext.Id };
            var questions = this._db.Query<QuestionDetailsView>(sqlQuery, parameters);
            return this._mapper.Map<IEnumerable<QuestionListItem>>(questions);
        }

        public IEnumerable<QuestionListItem> GetQuestionsAnsweredByEmployee(Guid employeeId)
        {
            var sqlQuery = "SELECT * FROM QuestionDetailsView WHERE Id IN (SELECT DISTINCT QuestionId FROM Answer WHERE AnsweredBy = @employeeId) AND CurrentEmployeeID = @currentEmployeeId";
            var questions = this._db.Query<QuestionDetailsView>(sqlQuery, new { employeeId = employeeId, currentEmployeeId = this._requestContext.Id });
            return this._mapper.Map<IEnumerable<QuestionListItem>>(questions);
        }

        public int AddQuestionActivity(EmployeeQuestionActivity newActivity)
        {
            var sqlQuery = "SELECT * FROM EmployeeQuestionActivity WHERE EmployeeId = @employeeId AND QuestionId = @questionId";
            var parameters = new { employeeId = newActivity.EmployeeId, questionId = newActivity.QuestionId };
            var existingActivity = this._db.QuerySingleOrDefault<Data.Models.EmployeeActivities.EmployeeQuestionActivity>(sqlQuery, parameters);

            if (existingActivity == null)
            {
                var activity = this._mapper.Map<Data.Models.EmployeeActivities.EmployeeQuestionActivity>(newActivity);
                this._db.Insert(activity);
            }

            var updatedViewCount = this._db.QuerySingleOrDefault<int>("SELECT COUNT(*) FROM EmployeeQuestionActivity WHERE QuestionId = @questionId", new { questionId = newActivity.QuestionId });

            return updatedViewCount;
        }

        public void UpdateQuestionActivity(EmployeeQuestionActivity newActivity)
        {
            var sqlQuery = "SELECT * FROM EmployeeQuestionActivity WHERE EmployeeId = @employeeId AND QuestionId = @questionId";
            var parameters = new { employeeId = newActivity.EmployeeId, questionId = newActivity.QuestionId };
            var existingActivity = this._db.QuerySingleOrDefault<Data.Models.EmployeeActivities.EmployeeQuestionActivity>(sqlQuery, parameters);

            if (existingActivity != null)
            {
                existingActivity.VoteStatus = newActivity.VoteStatus;
                this._db.Update(existingActivity);
            }
            else
            {
                var activity = this._mapper.Map<Data.Models.EmployeeActivities.EmployeeQuestionActivity>(newActivity);
                this._db.Insert(activity);
            }
        }

        public void ReportQuestion(Report newReport)
        {
            var report = this._mapper.Map<Data.Models.Report.Report>(newReport);
            this._db.Insert(report);
        }
    }
}