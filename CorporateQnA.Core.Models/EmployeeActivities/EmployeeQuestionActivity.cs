namespace CorporateQnA.Core.Models.EmployeeActivities
{
    public class EmployeeQuestionActivity
    {
        public EmployeeQuestionActivity()
        {
            this.ViewedOn = DateTime.UtcNow;
        }

        public Guid QuestionId { get; set; }

        public Guid EmployeeId { get; set; }

        public DateTime ViewedOn { get; set; }

        public short VoteStatus { get; set; }
    }
}
