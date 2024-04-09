using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class Owner : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }

        // khoa ngoai
        public int PetId { get; set; }
        public int LocationId { get; set; }
    }
}
