

using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Services;
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

        public async Task<int> AddAsync(Donor model)
        {
            context.Donors.Add(model);
            var r = await context.SaveChangesAsync();
            return r;
        }

        public async Task DeletePermanentlyAsync(Donor model)
        {
            context.Donors.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<PaginatedResult<Donor>> GetAllAsync(int pageNumber, int pageSize)
        {
            var donorsList = await context.Donors
                .Where(c => c.IsDeleted == false)
                .Include(c => c.Location)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var totalItems = await TotalItems();
            return new PaginatedResult<Donor>
            {
                Items = donorsList,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Donor?> GetByIdAsync(int id)
        {
            var r = await context.Donors
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
            return r;
        }

        public Task<int> SoftDelete(Donor model)
        {
            model.IsDeleted = !model.IsDeleted; 
            context.Donors.Update(model);
            return context.SaveChangesAsync();
        }


        public Task<int> TotalItems()
        {
            return context.Donors.CountAsync();
        }

        public async Task<int> UpdateAsync(Donor model)
        {
            context.Donors.Update(model);
            return await context.SaveChangesAsync();    
        }
    }
}
