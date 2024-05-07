using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;


namespace VolunteerRoles.Infrastructure.Repositories
{
    public class VolunteerRoleRepository : IVolunteerRoleRepository
    {
        private readonly AdoptPetDbContext _context;

        public VolunteerRoleRepository(AdoptPetDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<int> AddAsync(VolunteerRole model)
        {
            if(model != null)
            {
                await _context.VolunteerRoles.AddAsync(model);
            }
            
           var r = await _context.SaveChangesAsync();
            return r;
        }

        public async Task DeletePermanentlyAsync(VolunteerRole model)
        {
            _context.VolunteerRoles.Remove(model);
            await _context.SaveChangesAsync();
        }


        public async Task<PaginatedResult<VolunteerRole>> GetAllAsync(int pageNumber, int pageSize)
        {
            var volunteerRoles = await _context.VolunteerRoles
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
            var totalItems = await TotalItems();
            return new PaginatedResult<VolunteerRole>
            {
                Items =  volunteerRoles,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<VolunteerRole?> GetByIdAsync(int id)
        {
            return await _context.VolunteerRoles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<int> SoftDelete(VolunteerRole model)
        {
            model.IsDeleted = !model.IsDeleted; // Assuming Status field indicates soft delete
            _context.Entry(model).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task<int> TotalItems()
        {
            return _context.VolunteerRoles.CountAsync();
        }

        public async Task UpdateAsync(VolunteerRole model)
        {
            return _context.VolunteerRoles.CountAsync();
        }

        public async Task<int> UpdateAsync(VolunteerRole model)
        {
            _context.VolunteerRoles.Update(model);
            return await _context.SaveChangesAsync();
        }
    }
}
