using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class Breed : IEntity<int>
    {
        public int Id { get; set; }
        public string BreedName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ThumbPath { get; set; } = string.Empty;
        public byte Status { get; set; }
    }
}
