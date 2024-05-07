

using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.Infrastructure.Repositories
{
    public class OwnerRepository : IGenericRepository<Owner>
    {
        private readonly AdoptPetDbContext context;

        public OwnerRepository(AdoptPetDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddAsync(Owner model)
        {
            context.Owners.Add(model);
            var r = await context.SaveChangesAsync();
            return r;
        }

        public async Task DeletePermanentlyAsync(Owner model)
        {
            context.Owners.Remove(model);
            int afftectedRows = await context.SaveChangesAsync();
        }

        public async Task<PaginatedResult<Owner>> GetAllAsync(int pageNumber, int pageSize)
        {
            var ownerList = context.Owners.Where(c => c.IsDeleted == false)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var totalItems = await TotalItems();
            return new PaginatedResult<Owner>
            {
                Items = await ownerList,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Owner?> GetByIdAsync(int id)
        {
            var r = await context.Owners.Where(b => b.Id == id && b.IsDeleted == false).FirstOrDefaultAsync();
            return r;
        }

        public Task<int> SoftDelete(Owner model)
        {
            model.IsDeleted = true; 
            context.Owners.Update(model);
            return context.SaveChangesAsync();
        }

        public Task<int> TotalItems()
        {
            return context.Owners.CountAsync();
        }

        public Task<int> TotalItems()
        {
            return context.Owners.CountAsync();
        }

        public async Task UpdateAsync(Owner model)
        {
            context.Owners.Update(model);
            return await context.SaveChangesAsync();
        }
    }
}
