using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace AdoptPet.Infrastructure.Repositories
{
    public class ColourRepository : IGenericRepository<Colour>
    {
        private readonly AdoptPetDbContext context;
        public ColourRepository (AdoptPetDbContext context)
        {
            this.context = context;
        }

        public async Task<Colour?> AddAsync(Colour model)
        {
            context.Colours.Add(model);
            var r = await context.SaveChangesAsync();
            if (r > 0)
            {
                return model;
            }
            return null;
        }

        public async Task DeletePermanentlyAsync(Colour model)
        {
            context.Colours.Remove(model);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<Colour>> GetAllAsync()
        {
            var r = await context.Colours.ToListAsync();
            return r;
        }

        public async Task<Colour?> GetByIdAsync(int id)
        {
            var r = await context.Colours
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
            return r;
        }

        public async Task SoftDelete(Colour model)
        {
            model.IsDeleted = !model.IsDeleted; 
            context.Colours.Update(model);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Colour model)
        {
            context.Colours.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
