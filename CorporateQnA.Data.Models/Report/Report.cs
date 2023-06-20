using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateQnA.Data.Models.Report
{
    [Table("Report")]
    public class Report
    {
        [Key]
        public Guid Id { get; set; }

        public Guid QuestionId { get; set; }

        public Guid ReportedBy { get; set; }

        public string Description { get; set; }

        public DateTime ReportedOn { get; set; }
    }
}
