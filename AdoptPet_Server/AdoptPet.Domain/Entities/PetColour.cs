using AdoptPet.Domain.Common.Interfaces;


namespace AdoptPet.Domain.Entities
{
    public class PetColour : IEntity<int>
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int ColourId { get; set; }

        public Colour? Colour { get; set; }

        public bool IsDeleted { get; set; }
    }
}
