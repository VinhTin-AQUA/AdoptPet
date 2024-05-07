using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AdoptPet.Application.Interfaces.IRepositories
{
    public interface IRoleRepository
    {
        Task<IdentityResult> CreateRoleAsync(IdentityRole newRole);
        Task<IdentityResult> DeleteRoleAsync(string roleName);
        Task<IdentityResult> AddRoleRoUserAsync(AppUser user, string roleName);
        Task<ICollection<IdentityRole>> GetAllRoles(int pageNumber, int pageSize);
        Task<bool> RoleExits(string roleName);
        Task<List<string>> GetRoleOfUser(AppUser user);
    }
}
