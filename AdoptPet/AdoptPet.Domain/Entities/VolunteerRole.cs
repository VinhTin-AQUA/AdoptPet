using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class VolunteerRole : IEntity<int>
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
