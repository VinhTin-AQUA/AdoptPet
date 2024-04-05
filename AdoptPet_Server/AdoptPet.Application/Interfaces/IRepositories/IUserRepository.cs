using AdoptPet.Domain.Entities;

namespace AdoptPet.Application.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<List<AppUser>> GetAllUsers();
        Task<List<AppUser>> SearchUserByName(string name);
        Task LockUser(AppUser user);
        Task AddUser();
        Task RemoveUser(AppUser user);
    }
}
