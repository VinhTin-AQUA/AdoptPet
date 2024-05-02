using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;
namespace AdoptPet.Application.Interfaces.IRepositories
{
    public interface IPetRepository:IGenericRepository<Pet>
    {
        Task<PaginatedResult<Pet>> SearchPetsByBreedAsync(int breedId, int pageNumber, int pageSize);
        
    }
}