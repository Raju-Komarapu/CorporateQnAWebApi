using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateQnA.Data.Models.Employee
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Guid DesignationId { get; set; }

        public Guid DepartmentId { get; set; }

        public Guid LocationId { get; set; }

        public Guid UserId { get; set; }
    }
}