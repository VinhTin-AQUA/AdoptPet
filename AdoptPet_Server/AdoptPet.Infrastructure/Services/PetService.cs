using AdoptPet.Application.DTOs;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Application.Interfaces.IService;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Data.SqlTypes;

namespace AdoptPet.Infrastructure.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _repository;
        private readonly GlobalSettings _globalSettings;
        private readonly IPetImageRepository _petImageRepository;
        private readonly IImageService _imageService;
        private readonly IGenericRepository<Location> _locationRepository;
        public PetService(IPetRepository repository, IOptions<GlobalSettings> globalSettings, IPetImageRepository petImageRepository, IImageService imageService, IGenericRepository<Location> locationRepository)
        {
            _repository = repository;
            _globalSettings = globalSettings.Value;
            _petImageRepository = petImageRepository;
            _imageService = imageService;
            _locationRepository = locationRepository;
        }

        public async Task<PaginatedResult<Pet>> GetAllAsync(int pageNumber, int pageSize)
        {
            int totalItems = await _repository.TotalItems();
            String  validationMessage = await IPetService.ValidateNumber(totalItems,pageNumber, pageSize);
            if (!String.IsNullOrEmpty(validationMessage))
            {
                throw new InvalidDataException(validationMessage);
            }
            var listPet = await _repository.GetAllAsync(pageNumber, pageSize);
            if(listPet.Items == null)
            {
                throw new SqlNullValueException("List of pets is empty");
            }

            return listPet;
        }

        public async Task<PaginatedResult<Pet>> SearchPetsByBreedAsync(int breedId, int pageNumber, int pageSize)
        {
            return await _repository.SearchPetsByBreedAsync(breedId, pageNumber, pageSize);
        }


        public async Task<PaginatedResult<Pet>> SearchPetsByCriteria(SearchCriteria searchCriteria, int pageNumber, int pageSize)
        {
            int totalItems = await _repository.TotalItems();
            String validationMessage = await IGenericService<Pet>.ValidateNumber(totalItems, pageNumber, pageSize);
            if (!String.IsNullOrEmpty(validationMessage))
            {
                throw new InvalidDataException(validationMessage);
            }
            if (searchCriteria == null)
            {
                return await _repository.GetAllAsync(pageNumber, pageSize);
            }
            return await _repository.SearchPetByCriteria(searchCriteria, pageNumber, pageSize);
        }

        public async Task<Pet?> GetByIdAsync(int id)
        {
            if(id <= 0)
            {
                throw new InvalidDataException("Id must be greater than 0");
            }
            var pet = await _repository.GetByIdAsync(id);
            if(pet == null)
            {
                throw new SqlNullValueException("Pet not found");
            }
            return pet;
        }

        public async Task<int?> AddAsync(Pet pet)
        {
            if(pet == null)
            {
                throw new ArgumentException("Pet is null");
            }

            int affectedRows = await _repository.AddAsync(pet);
            if (affectedRows == 0)
            {
                throw new SqlNullValueException("Adding pet is failed");
            }
            return affectedRows;
        }

        public async Task<int?> UpdateAsync(int id, Pet pet)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("Id must be greater than 0");
            }
            if (pet == null)
            {
                throw new ArgumentNullException("Updating Pet model is null");
            }
            var petToUpdate = await _repository.GetByIdAsync(id);
            if (petToUpdate == null)
            {
                throw new ArgumentNullException("Pet not found");
            }
            petToUpdate.Status = pet.Status;
            petToUpdate.PetGender = pet.PetGender;
            petToUpdate.PetAge = pet.PetAge;
            petToUpdate.PetName = pet.PetName;
            petToUpdate.PetDescription = pet.PetDescription;
            petToUpdate.PetVaccined = pet.PetVaccined;
            petToUpdate.PetMicrochipped = pet.PetMicrochipped;
            petToUpdate.LocationId = pet.LocationId;
            petToUpdate.PetEntryDate = pet.PetEntryDate;
            petToUpdate.PetDesexed = pet.PetDesexed;
            petToUpdate.PetWeight = pet.PetWeight;
            petToUpdate.PetWormed = pet.PetWormed;
            petToUpdate.OwnerId = pet.OwnerId;
            petToUpdate.VolunteerId = pet.VolunteerId;
            int affectedRows = await _repository.UpdateAsync(petToUpdate);
            if (affectedRows == 0)
            {
                throw new SqlNullValueException("Updating pet is failed");
            }
            return affectedRows;
        }

        public async Task<int> SoftDelete(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("Id must be greater than 0");
            }
            var pet = await _repository.GetByIdAsync(id);
            if (pet == null)
            {
                throw new ArgumentNullException("Deleting pet is not found!");
            }
            int affectedRows = await _repository.SoftDelete(pet);
            if (affectedRows == 0)
            {
                throw new SqlNullValueException("Soft delete failed");
            }
            return affectedRows;
        }

        public async Task<int?> AddAsync(Pet model, List<IFormFile> formFile)
        {
            String invalidFileNames;
            if (formFile == null && _imageService.ValidateImagesExtension(formFile!, out invalidFileNames))
            {
                // add ", " between file names
                invalidFileNames = String.Join(", ", invalidFileNames);
                throw new InvalidDataException("Those images has invalid file extension: "+invalidFileNames);
            }
            if (model == null)
            {
                throw new ArgumentException("Pet is null");
            }

            // add location
            if(model.Location != null)
            {
                var generatedLocationId = await _locationRepository.AddAsync(model.Location);
                model.LocationId = generatedLocationId;
            }

            // add pet
            int generatedPetId = await _repository.AddAsync(model);
            if (generatedPetId == 0)
            {
                throw new SqlNullValueException("Adding pet is failed");
            }
            // add pet image
            if (formFile == null|| !formFile.Any())
            {
                model.PetImages.Add(new PetImage { PetId = generatedPetId ,ImgPath = _globalSettings.DefaultImage, IsDeleted = false  });
            }
            else
            {
                // save image to folder
                var imagePaths = await _imageService.SaveImagesAsync(_globalSettings.GlobalImagePath,"pets",formFile);
                // save image path to database
                foreach (var imagePath in imagePaths)
                {
                    model.PetImages.Add(new PetImage { PetId = generatedPetId, ImgPath = imagePath, IsDeleted = false });
                }
            }
            int affectedRows = await _petImageRepository.AddManyImagesAsync(model.PetImages);

            return generatedPetId;
        }

        public async Task<int?> UpdateAsync(int id, Pet pet, List<IFormFile> formFile)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("Id must be greater than 0");
            }
            if (pet == null)
            {
                throw new ArgumentNullException("Updating Pet model is null");
            }
            var petToUpdate = await _repository.GetByIdAsync(id);
            if (petToUpdate == null)
            {
                throw new ArgumentNullException("Pet not found");
            }
            petToUpdate.Status = pet.Status;
            petToUpdate.PetGender = pet.PetGender;
            petToUpdate.PetAge = pet.PetAge;
            petToUpdate.PetName = pet.PetName;
            petToUpdate.PetDescription = pet.PetDescription;
            petToUpdate.PetVaccined = pet.PetVaccined;
            petToUpdate.PetMicrochipped = pet.PetMicrochipped;
            petToUpdate.LocationId = pet.LocationId;
            petToUpdate.PetEntryDate = pet.PetEntryDate;
            petToUpdate.PetDesexed = pet.PetDesexed;
            petToUpdate.PetWeight = pet.PetWeight;
            petToUpdate.PetWormed = pet.PetWormed;
            petToUpdate.OwnerId = pet.OwnerId;
            petToUpdate.VolunteerId = pet.VolunteerId;
            int affectedRows = await _repository.UpdateAsync(petToUpdate);
            if (affectedRows == 0)
            {
                throw new SqlNullValueException("Updating pet is failed");
            }
            if (formFile != null && formFile.Any())
            {
                // save image to folder
                var imagePaths = await _imageService.SaveImagesAsync(_globalSettings.GlobalImagePath, "pets", formFile);
                // save image path to database
                foreach (var imagePath in imagePaths)
                {
                    petToUpdate.PetImages.Add(new PetImage { PetId = id, ImgPath = imagePath, IsDeleted = false });
                }
                affectedRows = await _petImageRepository.AddManyImagesAsync(petToUpdate.PetImages);
            }
            if(pet.Location != null)
            {
                var affectedRowsLocation = await _locationRepository.UpdateAsync(pet.Location);
                if(affectedRowsLocation == 0)
                {
                    throw new InvalidOperationException("Can't update location of pet");
                }
            }
            return affectedRows;
        }
    }
}
