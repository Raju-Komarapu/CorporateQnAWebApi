namespace CorporateQnA.Core.Models.Questions.ViewModels
{
    public class QuestionListItem
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public int NumberOfViews { get; set; }

        public int NumberOfAnswers { get; set; }

        public bool IsSolved { get; set; }

        public DateTime CreatedOn { get; set; }

        public int NumberOfUpVotes { get; set; }

        public short CurrentUserVoteStatus { get; set; }
    }
}
