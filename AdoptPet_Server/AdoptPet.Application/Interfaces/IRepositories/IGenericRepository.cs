using AdoptPet.Infrastructure.Services;

namespace AdoptPet.Application.Interfaces.IRepositories
{
    public interface IGenericRepository<T>
    {
        Task<T?> GetByIdAsync(int id);
        Task<PaginatedResult<T>> GetAllAsync(int pageNumber, int pageSize);
        Task<T?> AddAsync(T model);
        Task UpdateAsync(T model);
        Task DeletePermanentlyAsync(T model);
        Task SoftDelete(int Id);
    }
}
