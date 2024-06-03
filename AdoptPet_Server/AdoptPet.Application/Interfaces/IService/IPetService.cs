using AdoptPet.Application.DTOs;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Http;

namespace AdoptPet.Application.Interfaces.IService
{
    public interface IPetService : IGenericService<Pet>
    {
        public Task<int?> AddAsync(Pet model, List<IFormFile> formFile);
        public Task<int?> UpdateAsync(int id, Pet model, List<IFormFile> formFile);
        public Task<PaginatedResult<Pet>> SearchPetsByCriteria(SearchCriteria searchCriteria, int pageNumber, int pageSize);
    }
}
