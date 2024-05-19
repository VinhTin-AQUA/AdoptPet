using AdoptPet.Infrastructure.Services;

namespace AdoptPet.Application.Interfaces.IRepositories
{
    public interface IGenericRepository<T>
    {
        Task<T?> GetByIdAsync(int id);
        Task<PaginatedResult<T>> GetAllAsync(int pageNumber, int pageSize);
        Task<int> AddAsync(T model);
        Task<int> UpdateAsync(T model);
        Task DeletePermanentlyAsync(T model);
        Task<int> SoftDelete(T model);
        Task<int> TotalItems();
    }
}
