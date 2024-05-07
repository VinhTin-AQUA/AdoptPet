using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace AdoptPet.Infrastructure.Repositories
{
    public class DonorPetAuditRepository : IGenericRepository<DonorPetAudit>
    {
        private readonly AdoptPetDbContext context;
        public DonorPetAuditRepository(AdoptPetDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddAsync (DonorPetAudit model)
        {
            context.DonorPetAudits.Add(model);
            var r = await context.SaveChangesAsync();
            return r;
        }

        public async Task DeletePermanentlyAsync (DonorPetAudit model)
        {
            context.DonorPetAudits.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<PaginatedResult<DonorPetAudit>> GetAllAsync(int pageNumber, int pageSize)
        {
            var donorPetAudit = await context.DonorPetAudits
                .Where(c => c.IsDeleted == false)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var totalItems = context.DonorPetAudits.Count();
            return new PaginatedResult<DonorPetAudit>
            {
                Items = donorPetAudit,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<DonorPetAudit?> GetByIdAsync(int id)
        {
            var r = await context.DonorPetAudits.Where(b => b.Id == id).FirstOrDefaultAsync();
            return r;
        }

        public Task SoftDelete(int Id)
        {
            var donorPetAudit = context.DonorPetAudits.Find(Id);
            if (donorPetAudit != null)
            {
                donorPetAudit.IsDeleted = true;
                context.DonorPetAudits.Update(donorPetAudit);
                return context.SaveChangesAsync();
            }
            return Task.CompletedTask;
        }

        public Task<int> TotalItems()
        {
            return context.DonorPetAudits.CountAsync();
        }

        public async Task UpdateAsync (DonorPetAudit model)
        {
            context.DonorPetAudits.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
