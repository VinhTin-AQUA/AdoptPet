
namespace AdoptPet.Application.DTOs.BreedDto
{
    public class BreedDto
    {
        public int Id { get; set; }
        public string BreedName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public String? ThumbPath { get; set; }
    }
}
