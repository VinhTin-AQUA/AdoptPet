
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.Infrastructure.Repositories
{
    public class PetRepositories : IGenericRepository<Pet>
    {
        private readonly AdoptPetDbContext context;
        public PetRepositories(AdoptPetDbContext context)
        {
            this.context = context;
        }
        public async Task<Pet?> AddAsync(Pet model)
        {
            context.Pets.Add(model);
            var r = await context.SaveChangesAsync();
            if (r > 0)
            {
                return model;
            }
            return null;
        }

        public async Task DeletePermanentlyAsync(Pet model)
        {
            context.Pets.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<Pet>> GetAllAsync()
        {
            var r = await context.Pets.Where(c => c.Status == 0).ToListAsync();
            return r;
        }

        public async Task<Pet?> GetByIdAsync(int id)
        {
            var r = await context.Pets.Where(b => b.Id == id).FirstOrDefaultAsync();
            return r;
        }

        public async Task SoftDelete(Pet model)
        {
            model.Status = 1;
            context.Pets.Update(model);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pet model)
        {
            context.Pets.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
