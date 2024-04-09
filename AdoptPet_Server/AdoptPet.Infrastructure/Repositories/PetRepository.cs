using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly AdoptPetDbContext _context;

        public PetRepository(AdoptPetDbContext context)
        {
            _context = context;
        }
        public Task<Pet?> AddAsync(Pet model)
        {
            throw new NotImplementedException();
        }

        public Task DeletePermanentlyAsync(Pet model)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Pet>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pet?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Pet>> GetPetsByBreedAsync(int breedId)
        {
            var petsByBreed = from pet in _context.Pets
                            join petBreed in _context.PetBreeds on pet.Id equals petBreed.PetId
                            join breed in _context.Breeds on petBreed.BreedId equals breed.Id
                            where breed.Id == breedId
                            select pet;
            
            return await petsByBreed.ToListAsync();
        }


        public Task SoftDelete(Pet model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Pet model)
        {
            throw new NotImplementedException();
        }
    }
}