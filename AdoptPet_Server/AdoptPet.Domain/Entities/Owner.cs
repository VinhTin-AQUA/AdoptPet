using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class Owner : IEntity<int>
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;

        // khoa ngoai
        public int LocationId { get; set; }
        public Location? Location { get; set; }
    }
}
