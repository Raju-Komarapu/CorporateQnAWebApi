namespace CorporateQnA.Core.Models.Questions
{
    public class Question
    {
        public Question()
        {
            this.CreatedOn = DateTime.UtcNow.AddHours(5);
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
