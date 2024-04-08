using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptPet.Application.DTOs.PetDto;
using AdoptPet.Application.Interfaces;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;


namespace AdoptPet.Infrastructure.Services
{
 public class PetSearchService : IPetSearchService
  {
    private readonly IPetRepository _petRepository;
    public PetSearchService(IPetRepository petRepository)
      {
          _petRepository = petRepository;
      }

    public async Task<List<Pet>> GetPetsByBreedAsync(int breedId)
    {
        // Implement logic to get pets by breed from the repository
        // Example:
        return await _petRepository.GetPetsByBreedAsync(breedId);
    }

  }
}