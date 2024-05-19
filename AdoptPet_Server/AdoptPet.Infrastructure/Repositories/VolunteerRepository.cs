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
            var r = await _context.Volunteers
                        .Include(v => v.Location)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
            var totalItems = await TotalItems();
            return new PaginatedResult<Volunteer>
            {
                Items = r,
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


        public Task<int> SoftDelete(Volunteer existsVolunteer)
        {
            existsVolunteer.IsDeleted = true;
            _context.Volunteers.Update(existsVolunteer);
            return _context.SaveChangesAsync();
        }

        public Task<int> TotalItems()
        {
            return _context.Volunteers.CountAsync();
        }

        public async Task<int> UpdateAsync(Volunteer model)
        {
            _context.Volunteers.Update(model);
            return await _context.SaveChangesAsync();
        }

    }
}
