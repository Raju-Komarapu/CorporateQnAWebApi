namespace CorporateQnA.Core.Models.Report
{
    public class Report
    {
        public Report()
        {
            this.ReportedOn = DateTime.UtcNow;
        }

        public Guid Id { get; set; }

        public Guid QuestionId { get; set; }

        public Guid ReportedBy { get; set; }

        public string Description { get; set; }

        public DateTime ReportedOn { get; set; }
    }
}
