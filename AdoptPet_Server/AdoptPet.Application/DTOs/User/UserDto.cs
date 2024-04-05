using AdoptPet.Application.DTOs.BaseDto;

namespace AdoptPet.Application.DTOs.User
{
    public class UserDto : UserBaseDto
    {
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
    }
}
