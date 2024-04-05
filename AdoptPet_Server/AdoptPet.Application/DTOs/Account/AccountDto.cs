

using AdoptPet.Application.DTOs.BaseDto;

namespace AdoptPet.Application.DTOs.Account
{
    public class AccountDto : UserBaseDto
    {
        public string Token { get; set; } = string.Empty;
    }
}
