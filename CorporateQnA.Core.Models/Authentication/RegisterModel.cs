namespace CorporateQnA.Core.Models.Authentication
{
    public class RegisterModel
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid DesignationId { get; set; }

        public Guid DepartmentId { get; set; }

        public Guid LocationId { get; set; }
    }
}
