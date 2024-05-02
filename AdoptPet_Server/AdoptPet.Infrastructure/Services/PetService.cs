﻿using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptPet.Infrastructure.Services
{
    public class PetService
    {
        private readonly IPetRepository _repository;

        public PetService(IPetRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<Pet>> GetAllAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                throw new ArgumentException("Page number and page size must be greater than 0.");
            }

            return await _repository.GetAllAsync(pageNumber, pageSize);
        }

        public async Task<PaginatedResult<Pet>> SearchPetsByBreedAsync(string breed, int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                throw new ArgumentException("Page number and page size must be greater than 0.");
            }

            return await _repository.SearchPetsByBreedAsync(breed, pageNumber, pageSize);
        }

        public async Task<Pet> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Pet> AddAsync(Pet pet)
        {
            if(!ValidatePet(pet))
            {
                return null;
            }
            return await _repository.AddAsync(pet);
        }

        public async Task UpdateAsync(Pet pet)
        {
            if(!ValidatePet(pet))
            {
                throw new ArgumentException("Pet is not valid");
            }
            await _repository.UpdateAsync(pet);
        }

        public async Task SoftDelete(int id)
        {
            var pet = await _repository.GetByIdAsync(id);
            if (pet != null)
            {
                await _repository.SoftDelete(id);
            }

        }
        private bool ValidatePet(Pet pet)
        {
            var context = new ValidationContext(pet, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(pet, context, results, validateAllProperties: true))
            {
                var validationErrors = results.Select(r => r.ErrorMessage);
                return false;
            }
            return true;
        }

    }
}
