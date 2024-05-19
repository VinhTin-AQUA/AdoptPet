

using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.Infrastructure.Repositories
{
    public class LocationRepository : IGenericRepository<Location>
    {
        private readonly AdoptPetDbContext context;
        public LocationRepository (AdoptPetDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddAsync(Location model)
        {
            context.Locations.Add(model);
            var r = await context.SaveChangesAsync();
            return r;
        }
        
        public async Task DeletePermanentlyAsync(Location model)
        {
            context.Locations.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<PaginatedResult<Location>> GetAllAsync(int pageNumber, int pageSize)
        {
            var locationList = context.Locations
                .Where(c => c.IsDeleted == false)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var totalItems = await TotalItems();
            return new PaginatedResult<Location>
            {
                Items = await locationList,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task <Location?> GetByIdAsync(int id)
        {
            var r = await context.Locations.Where(b => b.Id == id && b.IsDeleted == false).FirstOrDefaultAsync();
            return r;
        }


        public Task<int> SoftDelete(Location model)
        {
            model.IsDeleted = true;
            context.Locations.Update(model);
            return context.SaveChangesAsync();
        }

        public Task<int> TotalItems()
        {
            return context.Locations.CountAsync();
        }

        public async Task<int> UpdateAsync(Location model)
        {
            context.Update(model);
            return await context.SaveChangesAsync();
        }
    }
}
