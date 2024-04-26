using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AdoptPet.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<SignInResult> SignInAsync(AppUser user, string password)
        {
            var r = await signInManager.PasswordSignInAsync(user, password, false, true);
            return r;
        }

        public async Task<IdentityResult> SignUpAsync(AppUser user, string password)
        {
            var r = await userManager.CreateAsync(user, password);
            return r;
        }

        public async Task<AppUser?> GetUserByEmailAsync(string email)
        {
            var r = await userManager.FindByEmailAsync(email);
            return r;
        }

        public async Task<AppUser?> GetUserByIdAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            return user;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(AppUser user)
        {
            return await userManager.GenerateEmailConfirmationTokenAsync(user);
        }


        public async Task<IdentityResult> ConfirmEmailAsync(AppUser user, string token)
        {
            var result = await userManager.ConfirmEmailAsync(user, token);
            return result;
        }

        public async Task<string> GeneratePasswordResetTokenAsync(AppUser user)
        {
            return await userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(AppUser user, string token, string newPassword)
        {
            var result = await userManager.ResetPasswordAsync(user, token, newPassword);
            return result;
        }

        public async Task<IdentityResult> ChangePasswordAsync(AppUser user, string oldPassword, string newPassword)
        {
            var result = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            return result;
        }
    }
}
