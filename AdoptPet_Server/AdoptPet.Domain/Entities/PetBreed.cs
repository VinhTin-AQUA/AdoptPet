using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class PetBreed : IEntity<int>
    {
        public int Id { get; set; }
        public int BreedId { get; set; }
        public int PetId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
