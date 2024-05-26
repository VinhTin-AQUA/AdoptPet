using AdoptPet.Application.DTOs.BreedDto;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using System.Data.SqlTypes;
using AdoptPet.Application.Interfaces.IService;
using Microsoft.AspNetCore.Http;
using AdoptPet.Application.DTOs;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;
namespace AdoptPet.Infrastructure.Services
{
    public class BreedService : IGenericServiceWithImage<Breed>
    {
        private readonly IGenericRepository<Breed> genericRepository;
        private readonly GlobalSettings _globalSettings;
        private readonly IImageService _imageService;

        public BreedService(IOptions<GlobalSettings> globalSettings,IGenericRepository<Breed> genericRepository, IImageService imageService)
        {
            this.genericRepository = genericRepository;
            this._globalSettings = globalSettings.Value;
            _imageService = imageService;
        }

        public async Task<int?> AddAsync(Breed model)
        {
            // kiểm tra model null
            if (model == null)
            {
                throw new ArgumentNullException("Model is null");
            }

            if (string.IsNullOrEmpty(model.BreedName) == true)
            {
                throw new ArgumentNullException("BreedName is null");
            }
            // tạo Breed
            Breed newBreed = new Breed()
            {
                BreedName = model.BreedName,
                Description = model.Description,
                ThumbPath = model.ThumbPath
            };
            var r = await genericRepository.AddAsync(newBreed);
            if (r == 0)
            {
                throw new SqlNullValueException("Adding breed is failed");
            }
            return r;
        }

        public async Task<int?> AddAsync(Breed model, IFormFile formFile)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Model is null");
            }

            if (string.IsNullOrEmpty(model.BreedName) == true)
            {
                throw new ArgumentNullException("BreedName is null");
            }
            if(formFile == null)
            {
                model.ThumbPath = _globalSettings.GlobalImagePath + "Breeds\\animal.png";
            }
            else
            {
                var globalPath = _globalSettings.GlobalImagePath;
                model.ThumbPath = await _imageService.SaveImageAsync(globalPath,"Breeds", formFile);
            }
            // tạo Breed
            Breed newBreed = new Breed()
            {
                BreedName = model.BreedName,
                Description = model.Description,
                ThumbPath = model.ThumbPath
            };
            var r = await genericRepository.AddAsync(newBreed);
            if (r == 0)
            {
                throw new SqlNullValueException("Adding breed is failed");
            }
            return r;
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            if(id <= 0)
            {
                throw new InvalidDataException("Id must be greater than 0");
            }
            var Breed = await genericRepository.GetByIdAsync(id);

            // kiểm tra Breed có tồn tại không
            if (Breed == null)
            {
                throw new ArgumentNullException("Deleting breed is not exists");
            }

            await genericRepository.DeletePermanentlyAsync(Breed);
        }

        public async Task<PaginatedResult<Breed>> GetAllAsync(int pageNumber, int pageSize)
        {
            int totalItems = await genericRepository.TotalItems();
            String validationMessage = await IGenericService<Breed>.ValidateNumber(totalItems, pageNumber, pageSize);
            if (!String.IsNullOrEmpty(validationMessage))
            {
                throw new InvalidDataException(validationMessage);
            }
            var r = await genericRepository.GetAllAsync(pageNumber, pageSize);
            if(r.Items == null)
            {
                throw new SqlNullValueException("No breed found");
            }
            return r;
        }

        public async Task<Breed?> GetByIdAsync(int id)
        {
            if(id <= 0)
            {
                throw new InvalidDataException("Id must be greater than 0");
            }
            var r = await genericRepository.GetByIdAsync(id);
            if (r == null)
            {
                throw new SqlNullValueException("Breed not found");
            }
            return r;
        }

        public async Task<int> SoftDelete(int id)
        {
            if(id <= 0)
            {
                throw new InvalidDataException("Id must be greater than 0");
            }
            var Breed = await genericRepository.GetByIdAsync(id);

            if (Breed == null)
            {
                throw new ArgumentNullException("Deleting breed is not exists");
            }
            int affectedRows = await genericRepository.SoftDelete(Breed);
            if (affectedRows == 0)
            {
                throw new SqlNullValueException("Soft delete failed");
            }
            return affectedRows;
        }

        public async Task<int?> UpdateAsync(int id, Breed model)
        {
            // tìm color
            if (id <= 0)
            {
                throw new InvalidDataException("Id must be greater than 0");
            }
            var oldBreed = await genericRepository.GetByIdAsync(id);

            // kiểm tra tìm thấy không
            if (oldBreed == null)
            {
                throw new ArgumentNullException("Updating breed is not found");
            }
            oldBreed.BreedName = model.BreedName; // gán lại màu đỏ
            oldBreed.Description = model.Description; // gán lại mô tả
            /*
             oldBreed.BreedName = "Black"
             */

            int affectedRows = await genericRepository.UpdateAsync(oldBreed);
            if(affectedRows == 0)
            {
                throw new SqlNullValueException("Update failed");
            }
            return affectedRows;
        }

        public async Task<int?> UpdateAsync(int id, Breed model, IFormFile formFile)
        {
            // tìm color
            if (id <= 0)
            {
                throw new InvalidDataException("Id must be greater than 0");
            }
            var oldBreed = await genericRepository.GetByIdAsync(id);

            // kiểm tra tìm thấy không
            if (oldBreed == null)
            {
                throw new ArgumentNullException("Updating breed is not found");
            }
            oldBreed.BreedName = model.BreedName; // gán lại màu đỏ
            oldBreed.Description = model.Description; // gán lại mô tả
            if (formFile == null)
            {
            }
            else
            {
                
                var globalPath = _globalSettings.GlobalImagePath;
                _imageService.DeleteOldImage(globalPath, "Breeds", oldBreed.ThumbPath);
                oldBreed.ThumbPath = await _imageService.SaveImageAsync(globalPath, "Breeds", formFile);
            }
            /*
             oldBreed.BreedName = "Black"
             */

            int affectedRows = await genericRepository.UpdateAsync(oldBreed);
            if (affectedRows == 0)
            {
                throw new SqlNullValueException("Update failed");
            }
            return affectedRows;
        }
    }
}
