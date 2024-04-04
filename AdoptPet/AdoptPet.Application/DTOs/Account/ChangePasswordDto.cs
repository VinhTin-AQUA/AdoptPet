using System.ComponentModel.DataAnnotations;

namespace AdoptPet.Application.DTOs.Account
{
    public class ChangePasswordDto
    {
        public string Email { get; set; } = string.Empty;
        public string OldPassword { get; set; } = string.Empty;

        public string NewPassword { get; set; } = string.Empty;

        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; } = string.Empty;
    }
}
