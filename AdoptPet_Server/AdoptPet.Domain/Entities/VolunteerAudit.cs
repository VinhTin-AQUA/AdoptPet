using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class VolunteerAudit : IEntity<int>
    {
        public int Id { get; set; }
        public byte OldStatus { get; set; }
        public byte NewStatus { get; set; }
        public DateTime LastChange { get; set; }

        public int VolunteerId { get; set; }
        public Volunteer? Volunteer { get; set; }
        public string UserId { get; set; } = string.Empty;
        public AppUser? User { get; set; }

        public string UserChangeId { get; set; } = string.Empty;
        public AppUser? UserChange { get; set; }

        public bool IsDeleted { get; set; }
    }
}
