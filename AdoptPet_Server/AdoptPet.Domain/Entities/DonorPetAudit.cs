using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class DonorPetAudit : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime LastDonation { get; set; }
        public int Version { get; set; }
        public decimal NewTotalDonation { get; set; }
        public decimal OldTotalDonation { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        // khoa ngoai
        public DonorPet DonorPet { get; set; }
    }
}
