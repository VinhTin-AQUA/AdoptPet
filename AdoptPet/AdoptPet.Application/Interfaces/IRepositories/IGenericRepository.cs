namespace AdoptPet.Application.Interfaces.IRepositories
{
    public interface IGenericRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<ICollection<T>> GetAllAsync();
        Task<T> AddAsync(T model);
        Task<T> UpdateAsync(T model);
        Task<T> DeleteAsync(T model);
    }
}
