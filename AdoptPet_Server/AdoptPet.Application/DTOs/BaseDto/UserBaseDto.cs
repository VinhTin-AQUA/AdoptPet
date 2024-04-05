

namespace AdoptPet.Application.DTOs.BaseDto
{
    public 
        class UserBaseDto
    {
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
    }
}
