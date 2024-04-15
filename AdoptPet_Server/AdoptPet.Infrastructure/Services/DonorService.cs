

using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Donor;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;

namespace AdoptPet.Infrastructure.Services
{
    
    public class DonorService
    {
        private readonly IGenericRepository<Donor> genericRepository;

        public DonorService(IGenericRepository<Donor> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        public async Task<Donor?> AddAsync(DonorDto model)
        {
            if(model == null)
            {
                return null;
            }
            if(string.IsNullOrEmpty(model.Name) == true)
            {
                return null;
            }
            Donor newDonor = new Donor()
            {
                Name = model.Name,
                TotalDonation = model.TotalDonation
            };

            var r = await genericRepository.AddAsync(newDonor);
            return r;
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            var donor = await genericRepository.GetByIdAsync(id);

            if (donor == null)
            {
                return;
            }
            await genericRepository.DeletePermanentlyAsync(donor);
        }

        public async Task<ICollection<Donor>> GetAllAsync()
        {
            var donors = await genericRepository.GetAllAsync();
            return donors;
        }

        public async Task<Donor?> GetByIdAsync(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            return r;
        }

        public async Task SoftDelete(int id)
        {
            var donor = await genericRepository.GetByIdAsync(id);

            if (donor == null)
            {
                return;
            }
            await genericRepository.SoftDelete(donor);
        }

        public async Task<Donor?> UpdateAsync(int id, DonorDto model)
        {
            var oldDonor = await genericRepository.GetByIdAsync(id);

            if (oldDonor == null)
            {
                return null;
            }
            oldDonor.Name = model.Name;
            oldDonor.TotalDonation = model.TotalDonation;

            await genericRepository.UpdateAsync(oldDonor);
            return oldDonor;
        }
    }
}
