using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections;

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

        public async Task<IdentityResult> CreateRoleAsync(IdentityRole newRole)
        {
            var r = await roleManager.CreateAsync(newRole);
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

        public async Task<ICollection<IdentityRole>> GetAllRoles()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return roles;
        }

        public async Task<bool> RoleExits(string roleName)
        {
            var r = await roleManager.FindByNameAsync(roleName);
            if (r == null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<string>> GetRoleOfUser(AppUser user)
        {
            var r = await userManager.GetRolesAsync(user);
            return r.ToList();
        }
    }
}
