namespace AdoptPet.Infrastructure.Services
{
    public interface IGenericService<T>
    {

        public Task<int?> AddAsync(T model);
        public Task<PaginatedResult<T>> GetAllAsync(int pageNumber, int pageSize);
        public Task<T?> GetByIdAsync(int id);
        public Task<int?> UpdateAsync(int id, T model);
        public Task<int> SoftDelete(int id);
        public static async Task<String> ValidateNumber(int totalItems, int pageNumber, int pageSize)
        {
            String message = "";
            if (pageNumber < 1 || pageSize < 1)
            {
                message = "Page number and page size must be greater than zero.";
            }

            var maxPageNumber = (int)Math.Ceiling((double)totalItems / pageSize);

            if (pageNumber > maxPageNumber)
            {
                message = "Page number exceeds the maximum number of pages.";
            }

            return message;
        }
    }
}
