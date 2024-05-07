using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.Infrastructure.Repositories
{
    public class BreedRepository : IGenericRepository<Breed>
    {
        private readonly AdoptPetDbContext _context;

        public BreedRepository(AdoptPetDbContext context)
        {
            this._context = context;
        }

        public async Task<int> AddAsync(Breed model)
        {
            _context.Breeds.Add(model);
            var r = await _context.SaveChangesAsync();
            return r;
        }

        public async Task DeletePermanentlyAsync(Breed model)
        {
            _context.Breeds.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedResult<Breed>> GetAllAsync(int pageNumber, int pageSize)
        {
            var breeds = await _context.Breeds
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
            var totalItems = await TotalItems();
            return new PaginatedResult<Breed>
            {
                Items =  breeds,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Breed?> GetByIdAsync(int id)
        {
            var r = await _context.Breeds
                .Where(b => b.Id == id && b.IsDeleted == false)
                .FirstOrDefaultAsync();
            return r;
        }


        public Task<int> SoftDelete(Breed model)
        {
            model.IsDeleted = true;
            _context.Breeds.Update(model);
            return _context.SaveChangesAsync();
        }

        public Task<int> TotalItems()
        {
            return _context.Breeds.CountAsync();
        }

        public Task<int> TotalItems()
        {
            return _context.Breeds.CountAsync();
        }

        public async Task UpdateAsync(Breed model)
        {
            _context.Breeds.Update(model);
            return await _context.SaveChangesAsync();
        }
    }
}
