
using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Owner;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;

namespace AdoptPet.Infrastructure.Services
{
    public class OwnerService
    {
        private readonly IGenericRepository<Owner> genericRepository;

        public OwnerService(IGenericRepository<Owner> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        public async Task<Owner?> AddAsync(OwnerDto model)
        {
            if(model == null)
            {
                return null;
            }
            if (string.IsNullOrEmpty(model.Name) == true)
            {
                return null;
            }
            Owner newOwner = new Owner()
            {
                
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

        public async Task<ICollection<Owner>> GetAllAsync()
        {
            var owners = await genericRepository.GetAllAsync();
            return owners;
        }

        public async Task<Owner?> GetByIdAsync(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            return r;
        }

        public async Task SoftDelete(int id)
        {
            var owner = await genericRepository.GetByIdAsync(id);

            if (owner == null)
            {
                return ;
            }
            await genericRepository.SoftDelete(owner);
        }

        public async Task<Owner?> UpdateAsync(int id, OwnerDto model)
        {
            var oldOwner = await genericRepository.GetByIdAsync(id);

            if (oldOwner == null)
            {
                return null;
            }

            await genericRepository.UpdateAsync(oldOwner);
            return oldOwner;
        }
    }
}
