using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class Location : IEntity<int>
    {
        public int Id { get; set; }
        public string Street { get; set; } = string.Empty;
        public string Wards { get; set; } = string.Empty;
        public string DistrictCity { get; set; } = string.Empty;
        public string ProvinceCity { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
