

namespace AdoptPet.Application.DTOs.DonorPetAudit
{
    public class DonorPetAuditDto
    {
        public DateTime LastDonation { get; set; }
        public int Version { get; set; }
        public decimal NewTotalDonation { get; set; }
        public decimal OldTotalDonation { get; set; }
    }
}
