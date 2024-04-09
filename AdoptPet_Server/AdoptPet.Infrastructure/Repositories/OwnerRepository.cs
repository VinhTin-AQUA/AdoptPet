

using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.Infrastructure.Repositories
{
    internal class OwnerRepository : IGenericRepository<Owner>
    {
        private readonly AdoptPetDbContext context;

        public OwnerRepository(AdoptPetDbContext context)
        {
            this.context = context;
        }
        public async Task<Owner?> AddAsync(Owner model)
        {
            context.Owners.Add(model);
            var r = await context.SaveChangesAsync();
            if (r > 0)
            {
                return model;
            }
            return null;
        }

        public async Task DeletePermanentlyAsync(Owner model)
        {
            context.Owners.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<Owner>> GetAllAsync()
        {
            var r = await context.Owners.Where(c => c.IsDeleted == false).ToListAsync();
            return r;
        }

        public async Task<Owner?> GetByIdAsync(int id)
        {
            var r = await context.Owners.Where(b => b.Id == id && b.IsDeleted == false).FirstOrDefaultAsync();
            return r;
        }

        public async Task SoftDelete(Owner model)
        {
            model.IsDeleted = true; 
            context.Owners.Update(model);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Owner model)
        {
            context.Owners.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
