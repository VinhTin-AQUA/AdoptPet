

using System.ComponentModel.DataAnnotations;

namespace AdoptPet.Application.DTOs.Account
{
    public class ResetPasswordDto
    {
        [Required]
        public string Token { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Pasword must be at least {2} and max length is {1} characters")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare("Password", ErrorMessage = "Confirm password is not match")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
