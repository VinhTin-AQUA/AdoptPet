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

        public async Task<ICollection<Breed>> GetAllAsync()
        {
            var r = await _context.Breeds.Where(c => c.IsDeleted == false).ToListAsync();
            return r;
        }

        public async Task<PaginatedResult<Breed>> GetAllAsync(int pageNumber, int pageSize)
        {
            var breeds = _context.Breeds
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
            var totalItems = _context.VolunteerRoles.Count();
            return new PaginatedResult<Breed>
            {
                Items = await breeds,
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


        public Task SoftDelete(int Id)
        {
            var breed = _context.Breeds.Find(Id);
            if(breed != null)
            {
                breed.IsDeleted = true;
                _context.Breeds.Update(breed);
                return _context.SaveChangesAsync();
            }
            return null;
        }

        public async Task UpdateAsync(Breed model)
        {
            _context.Breeds.Update(model);
            await _context.SaveChangesAsync();
        }

    }
}
