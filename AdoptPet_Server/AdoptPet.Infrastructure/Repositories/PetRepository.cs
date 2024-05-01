using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using PagedList;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AdoptPet.Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly AdoptPetDbContext _context;

        public PetRepository(AdoptPetDbContext context)
        {
            _context = context;
        }
        public async Task<Pet?> AddAsync(Pet model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            await _context.Pets.AddAsync(model);
            var r = await _context.SaveChangesAsync();
            return model;
        }

        public Task DeletePermanentlyAsync(Pet model)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedResult<Pet>> GetAllAsync(int pageNumber, int pageSize)
        {
            var petList = _context.Pets
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
            var totalItems = _context.Pets.Count();
            return new PaginatedResult<Pet>
            {
                Items = await petList,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Pet?> GetByIdAsync(int id)
        {
            Pet? pet = await _context.Pets.Where(p => p.Id == id).FirstOrDefaultAsync();
            return pet;
        }

        public async Task<PaginatedResult<Pet>> SearchPetsByBreedAsync(string breed, int pageNumber, int pageSize)
        {
            var listPets = from pet in _context.Pets
                        join petBreed in _context.PetBreeds
                        on pet.Id equals petBreed.PetId
                        join Breed in _context.Breeds
                        on petBreed.BreedId equals Breed.Id
                        where Breed.BreedName.Equals(breed, StringComparison.OrdinalIgnoreCase)
                        && pet.IsDeleted == false // Assuming you have a flag for soft deletes
                        select pet;
            var totalItems = listPets.Count();
            var paginatedQuery = listPets.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedResult<Pet>
            {
                Items = paginatedQuery,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public Task SoftDelete(Pet model)
        {
            model.IsDeleted = true;
            _context.Pets.Update(model);
            return _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Pet model)
        {
            _context.Pets.Update(model);
            return _context.SaveChangesAsync();
        }
    }
}