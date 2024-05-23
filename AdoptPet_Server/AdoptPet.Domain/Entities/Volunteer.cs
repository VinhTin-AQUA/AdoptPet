using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class Volunteer : IEntity<int>
    {
        public int Id { get; set; }
        
        public DateTime DateStart { get; set; }
        public bool IsDeleted { get; set; }

        // khoa ngoai
        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;

        public string UserId { get; set; } = string.Empty;
        public AppUser? User { get; set; }

        public ICollection<VolunteerRoleXVolunteer> VolunteerRoleXVolunteer { get; set; } = [];
    }
}
