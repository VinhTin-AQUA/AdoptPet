using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.DonorPet;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;

namespace AdoptPet.Infrastructure.Services
{
    public class DonorPetService : IGenericService<DonorPet>
    {
        private readonly IGenericRepository<DonorPet> genericRepository;
        public DonorPetService(IGenericRepository<DonorPet> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<int?> AddAsync(DonorPet model)
        {
            if(model == null)
            {
                throw new Exception("Adding Model is null");
            }
            DonorPet newDonorPet = new DonorPet()
            {
                LastDonation = model.LastDonation,
                TotalDonation = model.TotalDonation
            };

            var r = await genericRepository.AddAsync(newDonorPet);
            if (r == 0)
            {
                throw new Exception("Adding donor pet is failed");
            }
            return r;
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            var donorPet = await genericRepository.GetByIdAsync(id);

            if (donorPet == null)
            {
                throw new ArgumentNullException("Deleting Donor pet model is null");
            }
            await genericRepository.DeletePermanentlyAsync(donorPet);
        }

        public async Task<PaginatedResult<DonorPet>> GetAllAsync(int pageSize, int pageNumber)
        {
            int totalItems = await genericRepository.TotalItems();
            string message = await IGenericService<DonorPet>.ValidateNumber(totalItems, pageNumber, pageSize);
            if (String.IsNullOrEmpty(message))
            {
                throw new Exception(message);
            }
            var donorPets = await genericRepository.GetAllAsync(pageNumber, pageSize);
            if(donorPets.Items == null)
            {
                throw new ArgumentNullException("Can't get list of donor pet");
            }
            return donorPets;
        }
        public async Task<DonorPet?> GetByIdAsync(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            if(r == null)
            {
                throw new ArgumentNullException("Donor pet model is null");
            }
            return r;
        }
        public async Task<int> SoftDelete(int id)
        {
            var donorPet = await genericRepository.GetByIdAsync(id);

            if (donorPet == null)
            {
                throw new ArgumentNullException("Donor pet model is null");
            }
            int affectedRows = await genericRepository.SoftDelete(id);
            if (affectedRows == 0)
            {
                throw new Exception("Can't soft delete Donor pet model");
            }
            return affectedRows;
        }

        public async Task<int?> UpdateAsync(int id, DonorPet model)
        {
            var oldDonorPet = await genericRepository.GetByIdAsync(id);

            if (oldDonorPet == null)
            {
                throw new Exception("Updating Donor pet model is null");
            }
            oldDonorPet.LastDonation = model.LastDonation;
            oldDonorPet.TotalDonation = model.TotalDonation;

            int affectedRows = await genericRepository.UpdateAsync(oldDonorPet);
            if (affectedRows == 0)
            {
                throw new Exception("Updating Donor pet model is failed");
            }
            return affectedRows;
        }
    }
}
