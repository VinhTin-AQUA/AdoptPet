

using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.Infrastructure.Repositories
{
    public class DonorPetRepository : IGenericRepository<DonorPet>
    {
        private readonly AdoptPetDbContext context;
        public DonorPetRepository(AdoptPetDbContext context)
        {
            this.context = context;
        }

        public async Task<DonorPet?> AddAsync(DonorPet model)
        {
            context.DonorPets.Add(model);
            var r = await context.SaveChangesAsync();
            if (r > 0)
            {
                return model;
            }
            return null;
        }

        public async Task DeletePermanentlyAsync(DonorPet model)
        {
            context.DonorPets.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<DonorPet>> GetAllAsync()
        {
            var r = await context.DonorPets.Where(c => c.Status == 0).ToListAsync();
            return r;
        }
        public async Task<DonorPet?> GetByIdAsync(int id)
        {
            var r = await context.DonorPets
                .Where(b => b.Id == id && b.Status == 0)
                .FirstOrDefaultAsync();
            return r;
        }
        public async Task SoftDelete(DonorPet model)
        {
            model.Status = 1;
            context.DonorPets.Update(model);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DonorPet model)
        {
            context.DonorPets.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
