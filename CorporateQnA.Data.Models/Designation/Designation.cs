using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateQnA.Data.Models.Designation
{
    [Table("Designation")]
    public class Designation
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}
