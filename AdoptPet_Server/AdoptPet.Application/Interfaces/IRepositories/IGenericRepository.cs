namespace AdoptPet.Application.Interfaces.IRepositories
{
    public interface IGenericRepository<T>
    {
        Task<T?> GetByIdAsync(int id);
        Task<ICollection<T>> GetAllAsync();
        Task<T?> AddAsync(T model);
        Task UpdateAsync(T model);
        Task DeletePermanentlyAsync(T model);
        Task SoftDelete(T model);
    }
}
