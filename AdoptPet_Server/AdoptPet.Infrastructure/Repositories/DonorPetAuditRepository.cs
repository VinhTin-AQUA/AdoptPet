using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.Infrastructure.Repositories
{
    public class DonorPetAuditRepository : IGenericRepository<DonorPetAudit>
    {
        private readonly AdoptPetDbContext context;
        public DonorPetAuditRepository(AdoptPetDbContext context)
        {
            this.context = context;
        }

        public async Task<DonorPetAudit?> AddAsync (DonorPetAudit model)
        {
            context.DonorPetAudits.Add(model);
            var r = await context.SaveChangesAsync();
            if (r > 0)
            {
                return model;
            }
            return null;
        }

        public async Task DeletePermanentlyAsync (DonorPetAudit model)
        {
            context.DonorPetAudits.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<DonorPetAudit>> GetAllAsync()
        {
            var r = await context.DonorPetAudits
                .Include(dpa => dpa.Pet)
                .Include(dpa => dpa.Donor)
                .Where(b => b.IsDeleted == false).ToListAsync();
            return r;
        }

        public async Task<DonorPetAudit?> GetByIdAsync(int id)
        {
            var r = await context.DonorPetAudits.Where(b => b.Id == id && b.IsDeleted == false).FirstOrDefaultAsync();
            return r;
        }
        public async Task SoftDelete (DonorPetAudit model)
        {
            model.IsDeleted = true;
            context.DonorPetAudits.Update(model);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync (DonorPetAudit model)
        {
            context.DonorPetAudits.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
