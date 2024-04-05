using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.Infrastructure.Repositories
{
    public class BreedRepository : IGenericRepository<Breed>
    {
        private readonly AdoptPetDbContext context;

        public BreedRepository(AdoptPetDbContext context)
        {
            this.context = context;
        }

        public async Task<Breed?> AddAsync(Breed model)
        {
            context.Breeds.Add(model);
            var r = await context.SaveChangesAsync();
            if (r > 0)
            {
                return model;
            }
            return null;
        }

        public async Task DeletePermanentlyAsync(Breed model)
        {
            context.Breeds.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<Breed>> GetAllAsync()
        {
            var r = await context.Breeds.ToListAsync();
            return r;
        }

        public async Task<Breed?> GetByIdAsync(int id)
        {
            var r = await context.Breeds
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
            return r;
        }

        public async Task SoftDelete(Breed model)
        {
            model.Status = 1; // xóa mềm
            context.Breeds.Update(model);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Breed model)
        {
            context.Breeds.Update(model);
            await context.SaveChangesAsync();
        }

    }
}
