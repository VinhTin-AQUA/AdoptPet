

namespace AdoptPet.Application.DTOs.User
{
    public class UserDto
    {
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }
        public List<string> Roles { get; set; } = [];
    }
}
