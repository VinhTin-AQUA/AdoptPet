
using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Owner;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;

namespace AdoptPet.Infrastructure.Services
{
    public class OwnerService : IGenericService<Owner>
    {
        private readonly IGenericRepository<Owner> genericRepository;

        public OwnerService(IGenericRepository<Owner> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        public async Task<int?> AddAsync(Owner model)
        {
            if(model == null)
            {
                throw new Exception("Adding Model is null");
            }
            if (string.IsNullOrEmpty(model.Name) == true)
            {
                throw new Exception("Owner Name is null");
            }
            Owner newOwner = new Owner()
            {
                Name = model.Name,
                LocationId = model.LocationId
            };

            var r = await genericRepository.AddAsync(newOwner);
            return r;
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            var owner = await genericRepository.GetByIdAsync(id);

            if (owner == null)
            {
                return ;
            }
            await genericRepository.DeletePermanentlyAsync(owner);
        }

        public async Task<PaginatedResult<Owner>> GetAllAsync(int pageNumber, int pageSize)
        {
            int totalItems = await genericRepository.TotalItems();
            string message = await IGenericService<Owner>.ValidateNumber(totalItems, pageNumber, pageSize);
            if (String.IsNullOrEmpty(message))
            {
                throw new Exception(message);
            }

            var owners = await genericRepository.GetAllAsync(pageNumber, pageSize);
            if (owners.Items == null)
            {
                throw new ArgumentNullException("Can't get list of owner");
            }

            return owners;
        }

        public async Task<Owner?> GetByIdAsync(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            if (r == null)
            {
                return null;
            }
            return r;
        }

        public async Task<int> SoftDelete(int id)
        {
            var owner = await genericRepository.GetByIdAsync(id);

            if (owner == null)
            {
                throw new Exception("Owner not found");
            }
            int affectedRows = await genericRepository.SoftDelete(owner);
            if (affectedRows == 0)
            {
                throw new Exception("Owner is failed");
            }
            return affectedRows;
        }

        public async Task<int?> UpdateAsync(int id, Owner model)
        {
            var oldOwner = await genericRepository.GetByIdAsync(id);

            if (oldOwner == null)
            {
                throw new Exception("Updating owner not found");
            }
            oldOwner.LocationId = model.LocationId;
            oldOwner.Name = model.Name;
            int affectedRows = await genericRepository.UpdateAsync(oldOwner);
            if(affectedRows == 0)
            {
                throw new Exception("Updating owner is failed");
            }
            return affectedRows;
            
        }
    }
}
