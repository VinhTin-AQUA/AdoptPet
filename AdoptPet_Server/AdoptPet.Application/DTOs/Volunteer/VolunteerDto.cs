

using AdoptPet.Application.DTOs.Location;

namespace AdoptPet.Application.DTOs.Volunteer
{
    public class VolunteerDto
    {
        public string UserEmail { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public LocationDto Location { get; set; } = null!;
    }
}
