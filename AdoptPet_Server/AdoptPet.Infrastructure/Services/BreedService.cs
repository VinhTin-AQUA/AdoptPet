using AdoptPet.Application.DTOs.BreedDto;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;

namespace AdoptPet.Infrastructure.Services
{
    public class BreedService : IGenericService<Breed>
    {
        private readonly IGenericRepository<Breed> genericRepository;

        public BreedService(IGenericRepository<Breed> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<int?> AddAsync(Breed model)
        {
            // kiểm tra model null
            if (model == null)
            {
                throw new Exception("Model is null");
            }

            if (string.IsNullOrEmpty(model.BreedName) == true)
            {
                throw new Exception("BreedName is null");
            }
            // tạo Breed
            Breed newBreed = new Breed()
            {
                BreedName = model.BreedName
            };
            var r = await genericRepository.AddAsync(newBreed);
            if (r == 0)
            {
                throw new Exception("Adding breed is failed");
            }
            return r;
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            var Breed = await genericRepository.GetByIdAsync(id);

            // kiểm tra Breed có tồn tại không
            if (Breed == null)
            {
                throw new Exception("Deleting breed is not exists");
            }

            await genericRepository.DeletePermanentlyAsync(Breed);
        }

        public async Task<PaginatedResult<Breed>> GetAllAsync(int pageNumber, int pageSize)
        {
            int totalItems = await genericRepository.TotalItems();
            String validationMessage = await IGenericService<Breed>.ValidateNumber(totalItems, pageNumber, pageSize);
            if (String.IsNullOrEmpty(validationMessage))
            {
                throw new Exception(validationMessage);
            }
            var r = await genericRepository.GetAllAsync(pageNumber, pageSize);
            if(r.Items == null)
            {
                throw new Exception("No breed found");
            }
            return r;
        }

        public async Task<Breed?> GetByIdAsync(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            if (r == null)
            {
                throw new Exception("Breed not found");
            }
            return r;
        }

        public async Task<int> SoftDelete(int id)
        {
            var Breed = await genericRepository.GetByIdAsync(id);

            if (Breed == null)
            {
                throw new Exception("Deleting breed is not exists");
            }
            int affectedRows = await genericRepository.SoftDelete(Breed);
            if (affectedRows == 0)
            {
                throw new Exception("Soft delete failed");
            }
            return affectedRows;
        }

        public async Task<int?> UpdateAsync(int id, Breed model)
        {
            // tìm color
            var oldBreed = await genericRepository.GetByIdAsync(id);

            // kiểm tra tìm thấy không không
            if (oldBreed == null)
            {
                throw new Exception("Updating breed is not found");
            }
            oldBreed.BreedName = model.BreedName; // gán lại màu đỏ
            oldBreed.Description = model.Description; // gán lại mô tả
            /*
             oldBreed.BreedName = "Black"
             */

            int affectedRows = await genericRepository.UpdateAsync(oldBreed);
            if(affectedRows == 0)
            {
                throw new Exception("Update failed");
            }
            return affectedRows;
        }

    }
}
