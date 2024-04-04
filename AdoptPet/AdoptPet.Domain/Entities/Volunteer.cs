using AdoptPet.Domain.Common.Interfaces;

namespace AdoptPet.Domain.Entities
{
    public class Volunteer : IEntity<int>
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        public DateTime DateStart { get; set; }
        public byte Status { get; set; }

        // khoa ngoai
        public int LocationId { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
