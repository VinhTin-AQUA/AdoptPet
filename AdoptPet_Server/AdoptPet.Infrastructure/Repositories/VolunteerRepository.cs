using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.Infrastructure.Repositories
{
    public class VolunteerRepository : IGenericRepository<Volunteer>
    {
        private readonly AdoptPetDbContext context;

        public VolunteerRepository(AdoptPetDbContext context)
        {
            this.context = context;
        }

        public async Task<Volunteer?> AddAsync(Volunteer model)
        {
            context.Volunteers.Add(model);
            var r = await context.SaveChangesAsync();
            if(r < 1)
            {
                return null;
            }
            return model;
        }

        public async Task DeletePermanentlyAsync(Volunteer model)
        {
            context.Volunteers.Remove(model);
            await context.SaveChangesAsync();  
        }

        public async Task<ICollection<Volunteer>> GetAllAsync()
        {
            var r = await context.Volunteers.ToListAsync();
            return r;
        }

        public async Task<Volunteer?> GetByIdAsync(int id)
        {
            var r = await context.Volunteers
                .Where(v => v.Id == id)
                .FirstOrDefaultAsync();
            return r;
        }

        public async Task SoftDelete(Volunteer model)
        {
            model.IsDeleted = !model.IsDeleted;
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Volunteer model)
        {
            context.Volunteers.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
