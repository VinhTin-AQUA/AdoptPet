using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.Infrastructure.Repositories
{
    public class VolunteerRepository : IGenericRepository<Volunteer>
    {
        private readonly AdoptPetDbContext _context;

        public VolunteerRepository(AdoptPetDbContext context)
        {
            this._context = context;
        }

        public async Task<int> AddAsync(Volunteer model)
        {
            _context.Volunteers.Add(model);
            var r = await _context.SaveChangesAsync();
            return r;
        }

        public async Task DeletePermanentlyAsync(Volunteer model)
        {
            _context.Volunteers.Remove(model);
            await _context.SaveChangesAsync();  
        }

        public async Task<PaginatedResult<Volunteer>> GetAllAsync(int pageNumber, int pageSize)
        {
            var r = _context.Volunteers
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
            var totalItems = _context.Pets.Count();
            return new PaginatedResult<Volunteer>
            {
                Items = await r,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Volunteer?> GetByIdAsync(int id)
        {
            var r = await _context.Volunteers
                .Where(v => v.Id == id)
                .FirstOrDefaultAsync();
            return r;
        }

        public async Task SoftDelete(Volunteer model)
        {
            model.IsDeleted = !model.IsDeleted;
            await _context.SaveChangesAsync();
        }

        public Task SoftDelete(int Id)
        {
            var existsVolunteer = _context.Volunteers.Find(Id);
            if (existsVolunteer != null)
            {
                existsVolunteer.IsDeleted = true;
                _context.Volunteers.Update(existsVolunteer);
                _context.SaveChangesAsync();
            }
            return null;
        }

        public async Task UpdateAsync(Volunteer model)
        {
            _context.Volunteers.Update(model);
            await _context.SaveChangesAsync();
        }

    }
}
