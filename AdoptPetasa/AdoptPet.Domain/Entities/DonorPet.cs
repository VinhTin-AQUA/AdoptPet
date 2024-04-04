using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class DonorPet : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime LastDonation { get; set; }
        public decimal TotalDonation { get; set; }

        // khoa ngoai
        public int PetId { get; set; }
        public int DonorId { get; set; }
    }
}
