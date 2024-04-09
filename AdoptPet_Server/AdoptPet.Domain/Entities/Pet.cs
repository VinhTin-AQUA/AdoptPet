

using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class Pet : IEntity<int>
    {
        public int Id { get; set; }
        public string PetName { get; set; } = string.Empty;
        public string PetDescription { get; set; } = string.Empty;
        public decimal PetWeight { get; set; }
        public string PetAge { get; set; } = string.Empty;
        public bool PetGender { get; set; }
        public byte PetDesexed { get; set; }
        public byte PetWormed { get; set; }
        public byte PetVaccined { get; set; }
        public byte PetMicrochipped { get; set; }
        public DateTime PetEntryDate { get; set; }
        public byte Status { get; set; }
        public bool IsDeleted { get; set; }

        // khoa ngoai
        public int VolunteerId { get; set; }
        public int LocationId { get; set; }
        public int OwnerId { get; set; }
    }
}
