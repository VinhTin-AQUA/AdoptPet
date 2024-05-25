

using AdoptPet.Domain.Entities;

namespace AdoptPet.Application.DTOs.Volunteer
{
    public class VolunteerDto
    {
        public string UserEmail { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public AdoptPet.Domain.Entities.Location Location { get; set; } = null!;
    }
}
