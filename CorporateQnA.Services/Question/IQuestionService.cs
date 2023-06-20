using CorporateQnA.Core.Models.EmployeeActivities;
using CorporateQnA.Core.Models.Questions;
using CorporateQnA.Core.Models.Questions.ViewModels;
using CorporateQnA.Core.Models.Report;

namespace CorporateQnA.Services.Interfaces
{
    public interface IQuestionService
    {
        Guid AddQuestion(Question newQuestion);

        QuestionListItem GetQuestionById(Guid questionId);

        IEnumerable<QuestionListItem> GetAllQuestions();

        IEnumerable<QuestionListItem> GetQuestionsAskedByEmployee(Guid employeeId);

        IEnumerable<QuestionListItem> GetQuestionsAnsweredByEmployee(Guid employeeId);

        int AddQuestionActivity(EmployeeQuestionActivity newActivity);

        void UpdateQuestionActivity(EmployeeQuestionActivity newActivity);

        void ReportQuestion(Report newReport);
    }
}
