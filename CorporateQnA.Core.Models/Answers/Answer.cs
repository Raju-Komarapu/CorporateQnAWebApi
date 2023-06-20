namespace CorporateQnA.Core.Models.Answers
{
    public class Answer
    {
        public Answer()
        {
            this.AnsweredOn = DateTime.UtcNow;
        }

        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid QuestionId { get; set; }

        public Guid Answeredby { get; set; }

        public DateTime AnsweredOn { get; set; }
    }
}
