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

        public async Task<Breed?> AddAsync(Breed model)
        {
            _context.Breeds.Add(model);
            var r = await _context.SaveChangesAsync();
            if (r > 0)
            {
                return model;
            }
            return null;
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

        public async Task SoftDelete(Breed model)
        {
            model.IsDeleted = true; // xóa mềm
            _context.Breeds.Update(model);
            await _context.SaveChangesAsync();
        }

        public Task SoftDelete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Breed model)
        {
            _context.Breeds.Update(model);
            await _context.SaveChangesAsync();
        }

    }
}
