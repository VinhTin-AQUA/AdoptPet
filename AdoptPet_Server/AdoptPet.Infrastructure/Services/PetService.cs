using AdoptPet.Application.DTOs;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptPet.Infrastructure.Services
{
    public class PetService : IGenericService<Pet>
    {
        private readonly IPetRepository _repository;

        public PetService(IPetRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<Pet>> GetAllAsync(int pageNumber, int pageSize)
        {
            int totalItems = await _repository.TotalItems();
            String  validationMessage = await IGenericService<Pet>.ValidateNumber(totalItems,pageNumber, pageSize);
            if (String.IsNullOrEmpty(validationMessage))
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

// <<<<<<< HEAD
//         public async Task<Pet?> GetByIdAsync(int id)
// =======
//         public async Task<PaginatedResult<Pet>> SearchPetsByCriteria(SearchCriteria searchCriteria, int pageNumber, int pageSize)
//         {
//             if(searchCriteria == null)
//             {
//                 return await _repository.GetAllAsync(pageNumber, pageSize);
//             }
//             return await _repository.SearchPetByCriteria(searchCriteria, pageNumber, pageSize);
//         }

//         public async Task<Pet> GetByIdAsync(int id)
// >>>>>>> 5301649906a4cfdf71e82b861361376d70da3e02
//         {
//             var pet = await _repository.GetByIdAsync(id);

//             return pet;
//         }

        public async Task<PaginatedResult<Pet>> SearchPetsByCriteria(SearchCriteria searchCriteria, int pageNumber, int pageSize)
        {
            int totalItems = await _repository.TotalItems();
            String validationMessage = await IGenericService<Pet>.ValidateNumber(totalItems, pageNumber, pageSize);
            if (String.IsNullOrEmpty(validationMessage))
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


    }
}
