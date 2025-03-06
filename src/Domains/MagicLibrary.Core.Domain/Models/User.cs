using MagicLibrary.Core.Domain.Interfaces;

namespace MagicLibrary.Core.Domain.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateOnly? MembershipDate { get; set; }
    }
}
