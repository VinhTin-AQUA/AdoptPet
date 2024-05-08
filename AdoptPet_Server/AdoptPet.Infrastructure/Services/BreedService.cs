using AdoptPet.Application.DTOs.BreedDto;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptPet.Infrastructure.Services
{
    public class BreedService
    {
        private readonly IGenericRepository<Breed> genericRepository;

        public BreedService(IGenericRepository<Breed> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<int?> AddAsync(BreedDto model)
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
            String validationMessage = await ValidateNumber(pageNumber, pageSize);
            if (String.IsNullOrEmpty(validationMessage))
            {
                throw new Exception(validationMessage);
            }
            var r = await genericRepository.GetAllAsync(pageNumber, pageSize);
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

        public async Task SoftDelete(int id)
        {
            var Breed = await genericRepository.GetByIdAsync(id);

            if (Breed == null)
            {
                throw new Exception("Deleting breed is not exists");
            }
            await genericRepository.SoftDelete(Breed.Id);
        }

        public async Task<Breed?> UpdateAsync(int id, BreedDto model)
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

            await genericRepository.UpdateAsync(oldBreed);

            return oldBreed;
        }
        public async Task<String> ValidateNumber(int pageNumber, int pageSize)
        {
            String message = "";
            if (pageNumber < 1 || pageSize < 1)
            {
                message += "Page number and page size must be greater than zero.";
            }

            var totalItems = await genericRepository.TotalItems();
            var maxPageNumber = (int)Math.Ceiling((double)totalItems / pageSize);

            if (pageNumber > maxPageNumber)
            {
                message += "Page number exceeds the maximum number of pages.";
            }

            return message;
        }

    }
}
