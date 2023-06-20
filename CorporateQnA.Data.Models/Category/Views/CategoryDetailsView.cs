using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateQnA.Data.Models.Category.Views
{
    [Table("CategoryDetailsView")]
    public class CategoryDetailsView
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TotalNumberOfTags { get; set; }

        public int NumberOfTagsThisWeek { get; set; }

        public int NumberOfTagsThisMonth { get; set; }
    }
}
