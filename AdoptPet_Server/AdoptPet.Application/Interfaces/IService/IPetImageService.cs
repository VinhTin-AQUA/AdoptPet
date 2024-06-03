using AdoptPet.Application.DTOs;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Http;

namespace AdoptPet.Application.Interfaces.IService
{
    public interface IPetImageService : IGenericService<PetImageDTO>
    {
        public Task<ListPetImage> GetAllPetImageByPetId(int petId);
        public Task<int> UpdateManyImagesAsync(List<PetImageDTO> petImageDtos);
        public Task<int> AddManyImagesAsync(List<PetImageDTO> petImageDtos);
    }
}
