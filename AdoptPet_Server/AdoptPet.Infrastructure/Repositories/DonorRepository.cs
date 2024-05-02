

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

        public async Task<int?> AddAsync(Donor model)
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
            var donorsList = context.Donors
                .Where(c => c.IsDeleted == false)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var totalItems = context.Donors.Count();
            return new PaginatedResult<Donor>
            {
                Items = await donorsList,
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

        public async Task SoftDelete(Donor model)
        {
            model.IsDeleted = !model.IsDeleted; 
            context.Donors.Update(model);
            await context.SaveChangesAsync();
        }

        public Task SoftDelete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Donor model)
        {
            context.Donors.Update(model);
            await context.SaveChangesAsync();
        }

        Task<int> IGenericRepository<Donor>.AddAsync(Donor model)
        {
            throw new NotImplementedException();
        }
    }
}
