using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class Colour : IEntity<int>
    {
        public int Id { get; set; }
        public string ColourName { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
