

using AdoptPet.Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AdoptPet.Domain.Entities
{
    public class Pet : IEntity<int>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "PetName is required")]
        public string PetName { get; set; } = string.Empty;
        public string PetDescription { get; set; } = string.Empty;
        public decimal PetWeight { get; set; }
        public string PetAge { get; set; } = string.Empty;
        public byte PetGender { get; set; }
        public byte PetDesexed { get; set; }
        public byte PetWormed { get; set; }
        public byte PetVaccined { get; set; }
        public byte PetMicrochipped { get; set; }
        public DateTime PetEntryDate { get; set; }
        public byte Status { get; set; }
        public bool IsDeleted { get; set; }

        // khoa ngoai
        public int VolunteerId { get; set; }
        public Volunteer? Volunteer { get; set; }
        public int LocationId { get; set; }
        public Location? Location {  get; set; }
        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }

        public List<PetBreed> PetBreeds { get; set; } = [];
        public List<PetColour> PetColours { get; set;} = [];
        public List<PetImage> PetImages { get; set; } = [];
    }
}
