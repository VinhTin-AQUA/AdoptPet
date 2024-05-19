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
            var totalItems = await TotalItems();
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


        public Task<int> SoftDelete(Colour model)
        {
            model.IsDeleted = true;
            context.Colours.Update(model);
            return context.SaveChangesAsync();
        }

        public Task<int> TotalItems()
        {
            return context.Colours.CountAsync();
        }

        public async Task<int> UpdateAsync(Colour model)
        {
            context.Colours.Update(model);
            return await context.SaveChangesAsync();;
        }
    }
}
