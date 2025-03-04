namespace MagicLibrary.Core.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateOnly? MembershipDate { get; set; }
    }
}
