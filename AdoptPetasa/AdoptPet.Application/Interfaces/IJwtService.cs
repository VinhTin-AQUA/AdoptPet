

using AdoptPet.Domain.Entities;

namespace AdoptPet.Application.Interfaces
{
    public interface IJwtService
    {
        Task<string> CreateJWT(AppUser user);
    }
}
