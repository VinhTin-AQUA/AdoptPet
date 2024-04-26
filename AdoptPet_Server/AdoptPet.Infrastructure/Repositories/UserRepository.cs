using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> userManager;

        public UserRepository(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public Task AddUser()
        {
            throw new NotImplementedException();
        }

        public async Task<List<AppUser>> GetAllUsers()
        {
            var r = await userManager.Users.ToListAsync();
            return r;
        }

        public async Task<IdentityResult> LockUser(AppUser user)
        {
            DateTimeOffset lockDateTime = new DateTimeOffset(DateTime.Now.AddMinutes(30));
            var r = await userManager.SetLockoutEndDateAsync(user, lockDateTime);
            return r;
        }

        public async Task<IdentityResult> UnLockUser(AppUser user)
        {
            var r = await userManager.SetLockoutEndDateAsync(user, null);
            return r;
        }

        public Task RemoveUser(AppUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AppUser>> SearchUserByName(string name)
        {
            var users = await userManager.Users.Where(u => u.UserName!.ToLower().Contains(name.ToLower())).ToListAsync();
            return users;
        }
    }
}
