

using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
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
        public async Task<Location?> AddAsync(Location model)
        {
            context.Locations.Add(model);
            var r = await context.SaveChangesAsync();
            if (r > 0)
            {
                return model;
            }
            return null;
        }
        
        public async Task DeletePermanentlyAsync(Location model)
        {
            context.Locations.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<Location>> GetAllAsync()
        {
            var r = await context.Locations.Where(c => c.IsDeleted == false).ToListAsync();
            return r;
        }

        public async Task <Location?> GetByIdAsync(int id)
        {
            var r = await context.Locations.Where(b => b.Id == id && b.IsDeleted == false).FirstOrDefaultAsync();
            return r;
        }

        public async Task SoftDelete(Location model)
        {
            model.IsDeleted = true;
            context.Update(model);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Location model)
        {
            context.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
