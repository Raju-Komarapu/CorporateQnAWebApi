namespace CorporateQnA.Core.Models.Employees.ViewModels
{
    public class EmployeeListItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }

        public string Department { get; set; }

        public string Location { get; set; }

        public string ProfilePictureUrl { get; set; }

        public int NumberOfQuestionsAsked { get; set; }

        public int NumberOfQuestionsSolved { get; set; }

        public int NumberOfQuestionsAnswered { get; set; }

        public int NumberOfUpVotesRecieved { get; set; }

        public int NumberOfDownVotesRecieved { get; set; }
    }
}
