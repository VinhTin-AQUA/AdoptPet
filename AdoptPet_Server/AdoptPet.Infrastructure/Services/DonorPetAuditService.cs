

using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.DonorPetAudit;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;

namespace AdoptPet.Infrastructure.Services
{
    public class DonorPetAuditService
    {
        private readonly IGenericRepository<DonorPetAudit> genericRepository;
        public DonorPetAuditService(IGenericRepository<DonorPetAudit> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<int?> AddAsync(DonorPetAuditDto model)
        {
            if(model == null)
            {
                return null;
            }
            DonorPetAudit newDonorPetAudit = new DonorPetAudit()
            {
                LastDonation = model.LastDonation,
                Version = model.Version,
                NewTotalDonation = model.NewTotalDonation,
                OldTotalDonation = model.OldTotalDonation
            };

            var r = await genericRepository.AddAsync(newDonorPetAudit);
            return r;
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            var donorPetAudit = await genericRepository.GetByIdAsync(id);

            if (donorPetAudit == null)
            {
                return;
            }
            await genericRepository.DeletePermanentlyAsync(donorPetAudit);
        }

        public async Task<PaginatedResult<DonorPetAudit>> GetAllAsync(int pageNumber, int pageSize)
        {
            var donorPetAudits = await genericRepository.GetAllAsync(pageNumber, pageSize);
            return donorPetAudits;
        }

        public async Task<DonorPetAudit?> GetByIdAsync(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            return r;
        }
        public async Task SoftDelete(int id)
        {
            var donorPetAudit = await genericRepository.GetByIdAsync(id);

            if (donorPetAudit == null)
            {
                return ;
            }
            await genericRepository.SoftDelete(id);
        }

        public async Task<DonorPetAudit?> UpdateAsync(int id, DonorPetAuditDto model)
        {
            var oldDonorPetAudit = await genericRepository.GetByIdAsync(id);

            if (oldDonorPetAudit == null)
            {
                return null;
            }
            oldDonorPetAudit.LastDonation = model.LastDonation;
            oldDonorPetAudit.Version = model.Version;
            oldDonorPetAudit.NewTotalDonation = model.NewTotalDonation;
            oldDonorPetAudit.OldTotalDonation = model.OldTotalDonation;

            await genericRepository.UpdateAsync(oldDonorPetAudit);
            return oldDonorPetAudit;
        }
    }
}
