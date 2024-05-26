using AdoptPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.Application.Interfaces.IRepositories
{
    public interface IPetImageRepository :IGenericRepository<PetImage>
    {
        public Task<List<PetImage>> GetAllPetImageByPetId(int petId);
        public Task<int> AddManyImagesAsync(List<PetImage> images);
        public Task<int> UpdateManyImagesAsync(List<PetImage> images);
    }
}
