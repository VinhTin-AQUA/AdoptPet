

namespace AdoptPet.Application.DTOs.Owner
{
    public class OwnerDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public Domain.Entities.Location Location { get; set; }
    }
}
