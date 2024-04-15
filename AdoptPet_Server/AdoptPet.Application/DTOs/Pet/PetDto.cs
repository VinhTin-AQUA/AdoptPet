

namespace AdoptPet.Application.DTOs.Pet
{
    public class PetDto
    {
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
    }
}
