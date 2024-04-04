﻿using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class Donor : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal TotalDonation { get; set; }

        // khoa ngoai
        public int LocationId { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
