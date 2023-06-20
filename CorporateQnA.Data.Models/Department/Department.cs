using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CorporateQnA.Data.Models.Department
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}
