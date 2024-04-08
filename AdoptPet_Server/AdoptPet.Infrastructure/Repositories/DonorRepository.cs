

using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.Infrastructure.Repositories
{
    public class DonorRepository : IGenericRepository<Donor>
    {
        private readonly AdoptPetDbContext context;

        public DonorRepository(AdoptPetDbContext context)
        {
            this.context = context;
        }

        public async Task<Donor?> AddAsync(Donor model)
        {
            context.Donors.Add(model);
            var r = await context.SaveChangesAsync();
            if (r > 0)
            {
                return model;
            }
            return null;
        }

        public async Task DeletePermanentlyAsync(Donor model)
        {
            context.Donors.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<Donor>> GetAllAsync()
        {
            var r = await context.Donors.Where(c => c.Status == 0).ToListAsync();
            return r;
        }

        public async Task<Donor?> GetByIdAsync(int id)
        {
            var r = await context.Donors
                .Where(b => b.Id == id && b.Status == 0)
                .FirstOrDefaultAsync();
            return r;
        }

        public async Task SoftDelete(Donor model)
        {
            model.Status = 1; 
            context.Donors.Update(model);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Donor model)
        {
            context.Donors.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
