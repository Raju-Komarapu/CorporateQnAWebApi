using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateQnA.Data.Models.Location
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}
