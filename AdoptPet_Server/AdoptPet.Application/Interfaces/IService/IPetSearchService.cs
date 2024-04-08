

using AdoptPet.Application.DTOs.PetDto;
using AdoptPet.Domain.Entities;

namespace AdoptPet.Application.Interfaces
{
 public interface IPetSearchService
  {
      Task<List<Pet>> GetPetsByBreedAsync(int breedId);
  }
}