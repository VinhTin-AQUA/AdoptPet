

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
        public async Task<int?> AddAsync(Owner model)
        {
            context.Owners.Add(model);
            var r = await context.SaveChangesAsync();
            return r;
        }

        public async Task DeletePermanentlyAsync(Owner model)
        {
            context.Owners.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<PaginatedResult<Owner>> GetAllAsync(int pageNumber, int pageSize)
        {
            var ownerList = context.Owners.Where(c => c.IsDeleted == false)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var totalItems = context.Owners.Count();
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

        public async Task SoftDelete(Owner model)
        {
            model.IsDeleted = true; 
            context.Owners.Update(model);
            await context.SaveChangesAsync();
        }

        public Task SoftDelete(int Id)
        {
            var owner = context.Owners.Find(Id);
            if (owner != null)
            {
                owner.IsDeleted = true;
                context.Owners.Update(owner);
                return context.SaveChangesAsync();
            }
            return Task.CompletedTask;
        }

        public async Task UpdateAsync(Owner model)
        {
            context.Owners.Update(model);
            await context.SaveChangesAsync();
        }

        Task<int> IGenericRepository<Owner>.AddAsync(Owner model)
        {
            throw new NotImplementedException();
        }
    }
}
