using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateQnA.Data.Models.EmployeeActivities
{
    [Table("EmployeeQuestionActivity")]
    public class EmployeeQuestionActivity
    {
        [Key]
        public Guid Id { get; set; }

        public Guid QuestionId { get; set; }

        public Guid EmployeeId { get; set; }

        public DateTime ViewedOn { get; set; }

        public short VoteStatus { get; set; }
    }
}