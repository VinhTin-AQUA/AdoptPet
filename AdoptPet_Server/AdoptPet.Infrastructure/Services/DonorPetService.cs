using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.DonorPet;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;

namespace AdoptPet.Infrastructure.Services
{
    public class DonorPetService
    {
        private readonly IGenericRepository<DonorPet> genericRepository;
        public DonorPetService(IGenericRepository<DonorPet> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<int?> AddAsync(DonorPetDto model)
        {
            if(model == null)
            {
                return null;
            }
            DonorPet newDonorPet = new DonorPet()
            {
                LastDonation = model.LastDonation,
                TotalDonation = model.TotalDonation
            };

            var r = await genericRepository.AddAsync(newDonorPet);
            return r;
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            var donorPet = await genericRepository.GetByIdAsync(id);

            if (donorPet == null)
            {
                return ;
            }
            await genericRepository.DeletePermanentlyAsync(donorPet);
        }

        public async Task<PaginatedResult<DonorPet>> GetAllAsync(int pageSize, int pageNumber)
        {
            var donorPets = await genericRepository.GetAllAsync(pageNumber, pageSize);
            return donorPets;
        }
        public async Task<DonorPet?> GetByIdAsync(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            return r;
        }
        public async Task SoftDelete(int id)
        {
            var donorPet = await genericRepository.GetByIdAsync(id);

            if (donorPet == null)
            {
                return ;
            }
            await genericRepository.SoftDelete(id);
        }

        public async Task<DonorPet?> UpdateAsync(int id, DonorPetDto model)
        {
            var oldDonorPet = await genericRepository.GetByIdAsync(id);

            if (oldDonorPet == null)
            {
                return null;
            }
            oldDonorPet.LastDonation = model.LastDonation;
            oldDonorPet.TotalDonation = model.TotalDonation;

            await genericRepository.UpdateAsync(oldDonorPet);
            return oldDonorPet;
        }
    }
}
