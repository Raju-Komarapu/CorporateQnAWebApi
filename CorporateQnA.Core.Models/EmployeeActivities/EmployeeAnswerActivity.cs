namespace CorporateQnA.Core.Models.EmployeeActivities
{
    public class EmployeeAnswerActivity
    {
        public Guid AnswerId { get; set; }

        public Guid EmployeeId { get; set; }

        public short VoteStatus { get; set; }
    }

}
