using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using AdoptPet.Application.DTOs;
using Microsoft.Data.SqlClient;

namespace AdoptPet.Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly AdoptPetDbContext _context;

        public PetRepository(AdoptPetDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Pet model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            await _context.Pets.AddAsync(model);
            var r = await _context.SaveChangesAsync();
            return r;
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

        public async Task<PaginatedResult<Pet>> SearchPetByCriteria(SearchCriteria searchCriteria, int pageNumber, int pageSize)
        {

            var query = _context.Pets.AsQueryable(); // Start with the Pet table

            // Filter by Name (if provided)
            if (!string.IsNullOrEmpty(searchCriteria.Name))
            {
                query = query.Where(p => p.PetName.Contains(searchCriteria.Name));
            }

            // Filter by Breed (if provided)
            if (searchCriteria.BreedIds != null && searchCriteria.BreedIds.Length > 0)
            {
                query = query.Join(_context.PetBreeds, p => p.Id, pb => pb.PetId, (p, pb) => new { Pet = p, PetBreed = pb })
                             .Where(x => searchCriteria.BreedIds.Contains(x.PetBreed.BreedId))
                             .Select(x => x.Pet);
            }

            // Filter by Color (if provided)
            if (searchCriteria.ColourIds != null && searchCriteria.ColourIds.Length > 0)
            {
                query = query.Join(_context.PetColours, p => p.Id, pc => pc.PetId, (p, pc) => new { Pet = p, PetColour = pc })
                             .Where(x => searchCriteria.ColourIds.Contains(x.PetColour.ColourId))
                             .Select(x => x.Pet);
            }

            // Filter by Sex (if provided)
            if (searchCriteria.Sex.HasValue)
            {
                query = query.Where(p => p.PetGender == searchCriteria.Sex.Value);
            }

            // Filter by Desexed (if provided)
            if (searchCriteria.Desexed.HasValue)
            {
                query = query.Where(p => p.PetDesexed == (searchCriteria.Desexed.Value ? 1 : 0));
            }

            if(searchCriteria.AgeRange != null)
            {
                query = query.Where(p => p.PetAge == searchCriteria.AgeRange);
            }
            //Take the total count before applying pagination
            var totalItems = await query.CountAsync();
            // Apply pagination
            var paginatedQuery = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedResult<Pet>
            {
                Items = paginatedQuery,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

        }

        public async Task<PaginatedResult<Pet>> SearchPetsByBreedAsync(int breedId, int pageNumber, int pageSize)
        {
            var listPets = from pet in _context.Pets
                           join petBreed in _context.PetBreeds
                           on pet.Id equals petBreed.PetId
                           join Breed in _context.Breeds
                           on petBreed.BreedId equals Breed.Id
                           where Breed.Id == breedId
                           && pet.IsDeleted == false // Assuming you have a flag for soft deletes
                           select pet;
            var totalItems = await listPets.CountAsync();
            var paginatedQuery = await listPets.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedResult<Pet>
            {
                Items = paginatedQuery,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public Task SoftDelete(int Id)
        {
            var pet = _context.Pets.Find(Id);
            if (pet != null)
            {
                pet.IsDeleted = true;
                _context.Pets.Update(pet);
                return _context.SaveChangesAsync();
            }
            return null;
        }

        public Task UpdateAsync(Pet model)
        {
            _context.Pets.Update(model);
            return _context.SaveChangesAsync();
        }
    }
}