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
        public async Task<VolunteerRole?> AddAsync(VolunteerRole model)
        {
            await _context.VolunteerRoles.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task DeletePermanentlyAsync(VolunteerRole model)
        {
            _context.VolunteerRoles.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<VolunteerRole>> GetAllAsync()
        {
            return await _context.VolunteerRoles.ToListAsync();
        }

        public async Task<PaginatedResult<VolunteerRole>> GetAllAsync(int pageNumber, int pageSize)
        {
            var volunteerRoles = _context.VolunteerRoles
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
            var totalItems = _context.VolunteerRoles.Count();
            return new PaginatedResult<VolunteerRole>
            {
                Items = await volunteerRoles,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<VolunteerRole?> GetByIdAsync(int id)
        {
            return await _context.VolunteerRoles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SoftDelete(VolunteerRole model)
        {
            model.IsDeleted = !model.IsDeleted; // Assuming Status field indicates soft delete
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public Task SoftDelete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(VolunteerRole model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


    }
}
