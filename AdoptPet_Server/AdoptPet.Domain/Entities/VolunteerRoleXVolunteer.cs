

using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class VolunteerRoleXVolunteer : IEntity<int>
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        // khoa ngoai
        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; } = null!;

        public int RoleId { get; set; }
        public VolunteerRole Role { get; set; } = null!;
    }
}
