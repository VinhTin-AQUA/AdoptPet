

using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class VolunteerRoleXVolunteer : IEntity<int>
    {
        public int Id { get; set; }
        public int VolunteerId { get; set; }
        public string RoleId { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
