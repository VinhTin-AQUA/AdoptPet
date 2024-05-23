using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class PetImage : IEntity<int>
    {
        public int Id { get; set; }
        public string ImgPath { get; set; } = string.Empty;
        public int PetId { get; set; }
        public Pet? Pet { get; set; }
        public bool IsDeleted { get; set; }
    }
}
