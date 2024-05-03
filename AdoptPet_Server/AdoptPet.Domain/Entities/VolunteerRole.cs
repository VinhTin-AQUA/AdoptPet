using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class VolunteerRole : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }

        public ICollection<VolunteerRoleXVolunteer> VolunteerRoleXVolunteer { get; set; } = [];
    }
}
