

using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.Infrastructure.Repositories
{
    public class VolunteerRoleXVolunteerRepository
    {
        private readonly AdoptPetDbContext _context;

        public VolunteerRoleXVolunteerRepository(AdoptPetDbContext context)
        {
            this._context = context;
        }

        public async Task<List<VolunteerRole>> GetVolunteerRolesByVolunteerId(int volunteerId)
        {
            var volunteerRoles = await _context.VolunteerRoleXVolunteers
                           .Where(vv => vv.VolunteerId == volunteerId)
                           .Select(v => v.Role)
                           .ToListAsync();

            return volunteerRoles;
        }
    }
}
