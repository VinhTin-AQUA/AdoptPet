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

        public async Task<ICollection<Pet>> GetAllAsync()
        {
            List<Pet> pets = await _context.Pets.ToListAsync();
            return pets;
        }

        public async Task<Pet?> GetByIdAsync(int id)
        {
            Pet? pet = await _context.Pets.Where(p => p.Id == id).FirstOrDefaultAsync();
            return pet;
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