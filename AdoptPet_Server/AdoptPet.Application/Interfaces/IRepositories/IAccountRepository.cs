using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AdoptPet.Application.Interfaces.IRepositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(AppUser user, string password);
        Task<SignInResult> SignInAsync(AppUser user, string password);
        Task<AppUser?> GetUserByEmailAsync(string email);
        Task<AppUser?> GetUserByIdAsync(string userId);

        Task<string> GenerateEmailConfirmationTokenAsync(AppUser user);

        Task<IdentityResult> ConfirmEmailAsync(AppUser user, string token);

        Task<string> GeneratePasswordResetTokenAsync(AppUser user);

        Task<IdentityResult> ResetPasswordAsync(AppUser user, string token, string newPassword);

        Task<IdentityResult> ChangePasswordAsync(AppUser user, string oldPassword, string newPassword);
    }
}
