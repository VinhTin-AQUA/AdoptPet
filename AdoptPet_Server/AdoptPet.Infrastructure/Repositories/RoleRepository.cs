using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AdoptPet.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public RoleRepository(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IdentityResult> AddRoleRoUserAsync(AppUser user, string roleName)
        {
            var r = await userManager.AddToRoleAsync(user, roleName);
            return r;
        }

        public async Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            var r = await roleManager.CreateAsync(new IdentityRole(roleName));
            return r;
        }

        public async Task<IdentityResult> DeleteRoleAsync(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return new IdentityResult();
            }
            var r = await roleManager.DeleteAsync(role);
            return r;
        }
    }
}
