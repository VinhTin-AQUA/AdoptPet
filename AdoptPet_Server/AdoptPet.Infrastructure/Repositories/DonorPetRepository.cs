

using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Services;
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

        public async Task<int> AddAsync(DonorPet model)
        {
            context.DonorPets.Add(model);
            var r = await context.SaveChangesAsync();
            return r;
        }

        public async Task DeletePermanentlyAsync(DonorPet model)
        {
            context.DonorPets.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<PaginatedResult<DonorPet>> GetAllAsync(int pageNumber, int pageSize)
        {
            var donorPetList = context.DonorPets
                .Where(c => c.IsDeleted == false)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var totalItems = context.DonorPets.Count();
            return new PaginatedResult<DonorPet>
            {
                Items = await donorPetList,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<DonorPet?> GetByIdAsync(int id)
        {
            var r = await context.DonorPets
                .Where(b => b.Id == id && b.IsDeleted == false)
                .FirstOrDefaultAsync();
            return r;
        }

        public Task SoftDelete(int Id)
        {
            var model = context.DonorPets.Find(Id);
            if (model != null)
            {
                model.IsDeleted = true;
                context.DonorPets.Update(model);
                context.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public Task<int> TotalItems()
        {
            return context.DonorPets.CountAsync();
        }

        public async Task UpdateAsync(DonorPet model)
        {
            context.DonorPets.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
