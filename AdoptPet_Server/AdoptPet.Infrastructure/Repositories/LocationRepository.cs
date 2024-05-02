

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
        public async Task<int?> AddAsync(Location model)
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
            var totalItems = context.Locations.Count();
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


        public Task SoftDelete(int Id)
        {
            var location = context.Locations.Find(Id);
            if (location != null)
            {
                location.IsDeleted = true;
                context.Locations.Update(location);
                return context.SaveChangesAsync();
            }
            return null;
        }

        public async Task UpdateAsync(Location model)
        {
            context.Update(model);
            await context.SaveChangesAsync();
        }

        Task<int> IGenericRepository<Location>.AddAsync(Location model)
        {
            throw new NotImplementedException();
        }
    }
}
