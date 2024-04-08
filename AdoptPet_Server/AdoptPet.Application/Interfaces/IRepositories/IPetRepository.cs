using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptPet.Domain.Entities;

namespace AdoptPet.Application.Interfaces.IRepositories
{
    public interface IPetRepository: IGenericRepository<Pet>
    {
        Task<List<Pet>> GetPetsByBreedAsync(int breedId);
    }
}