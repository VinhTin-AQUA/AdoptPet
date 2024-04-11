using AdoptPet.Domain.Entities;

namespace AdoptPet.Application.DTOs.PetDto
{
    public class PetDto
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public string PetDescription { get; set; }
        public decimal PetWeight { get; set; }
        public string PetAge { get; set; }
        public byte PetGender { get; set; } // Assuming PetGender is a bool as you defined in Pet class
        public byte PetDesexed { get; set; }
        public byte PetWormed { get; set; }
        public byte PetVaccined { get; set; }
        public byte PetMicrochipped { get; set; }
        public DateTime PetEntryDate { get; set; }
        public string BreedName { get; set; }
        public string BreedDescription { get; set; }
        public string ThumbPath { get; set; } // Assuming this is a URL to an image of the breed.

        // You need to add converters for the byte properties from Pet entity to bool properties here if necessary
        // For example:
        public PetDto(Pet pet, Breed breed)
        {
            Id = pet.Id;
            PetName = pet.PetName;
            PetDescription = pet.PetDescription;
            PetWeight = pet.PetWeight;
            PetAge = pet.PetAge;
            PetGender = pet.PetGender;
            PetDesexed = pet.PetDesexed;
            PetWormed = pet.PetWormed;
            PetVaccined = pet.PetVaccined;
            PetMicrochipped = pet.PetMicrochipped;
            PetEntryDate = pet.PetEntryDate;
            BreedName = breed.BreedName;
            BreedDescription = breed.Description;
            ThumbPath = breed.ThumbPath;
        }
    }
}