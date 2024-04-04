using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AdoptPet.Application.Interfaces.IRepositories
{
    public interface IRoleRepository
    {
        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<IdentityResult> DeleteRoleAsync(string roleName);
        Task<IdentityResult> AddRoleRoUserAsync(AppUser user, string roleName);
    }
}
