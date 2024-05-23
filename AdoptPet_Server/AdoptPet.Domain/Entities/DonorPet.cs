﻿using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class DonorPet : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime LastDonation { get; set; }
        public decimal TotalDonation { get; set; }
        public bool IsDeleted { get; set; }

        // khoa ngoai
        public int PetId { get; set; }
        public Pet Pet { get; set; }

        public int DonorId { get; set; }
        public Donor? Donor { get; set; }


        public static implicit operator DonorPet(int? v)
        {
            throw new NotImplementedException();
        }
    }
}
