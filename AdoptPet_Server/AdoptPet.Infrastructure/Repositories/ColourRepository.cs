using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Services;
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

        public async Task<int> AddAsync(Colour model)
        {
            context.Colours.Add(model);
            var r = await context.SaveChangesAsync();
            return r;
        }

        public async Task DeletePermanentlyAsync(Colour model)
        {
            context.Colours.Remove(model);
            await context.SaveChangesAsync();
        }


        public async Task<PaginatedResult<Colour>> GetAllAsync(int pageNumber, int pageSize)
        {
            var colourList = await context.Colours
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var totalItems = context.Colours.Count();
            return new PaginatedResult<Colour>
            {
                Items =  colourList,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Colour?> GetByIdAsync(int id)
        {
            var r = await context.Colours
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
            return r;
        }


        public Task SoftDelete(int Id)
        {
            var colour = context.Colours.Find(Id);
            if (colour != null)
            {
                colour.IsDeleted = true;
                context.Colours.Update(colour);
                return context.SaveChangesAsync();
            }
            return Task.CompletedTask;
        }

        public async Task UpdateAsync(Colour model)
        {
            context.Colours.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
