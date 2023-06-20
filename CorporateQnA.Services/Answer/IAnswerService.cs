using CorporateQnA.Core.Models.Answers;
using CorporateQnA.Core.Models.Answers.ViewModels;
using CorporateQnA.Core.Models.EmployeeActivities;

namespace CorporateQnA.Services.Interfaces
{
    public interface IAnswerService
    {
        IEnumerable<AnswerListItem> GetAnswersByQuestionId(Guid questionId);

        Guid AddAnswer(Answer answer);

        void UpdateAnswerActivity(EmployeeAnswerActivity newActivity);

        void UpdateBestSolution(Guid answerId);

        AnswerListItem GetAnswer(Guid id);
    }
}
