using AdoptPet.Application.DTOs.DonorPetAudit;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using System.Data.SqlTypes;

namespace AdoptPet.Infrastructure.Services
{
    public class DonorPetAuditService : IGenericService<DonorPetAudit>
    {
        private readonly IGenericRepository<DonorPetAudit> genericRepository;
        public DonorPetAuditService(IGenericRepository<DonorPetAudit> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<int?> AddAsync(DonorPetAudit model)
        {
            if(model == null)
            {
                throw new ArgumentNullException("Adding Model is null");
            }
            DonorPetAudit newDonorPetAudit = new DonorPetAudit()
            {
                LastDonation = model.LastDonation,
                Version = model.Version,
                NewTotalDonation = model.NewTotalDonation,
                OldTotalDonation = model.OldTotalDonation
            };

            var r = await genericRepository.AddAsync(newDonorPetAudit);
            if (r == 0)
            {
                throw new SqlNullValueException("Adding donor pet audit is failed");
            }
            return r;
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            var donorPetAudit = await genericRepository.GetByIdAsync(id);

            if (donorPetAudit == null)
            {
                throw new ArgumentNullException("Donor pet audit model is null");
            }
            await genericRepository.DeletePermanentlyAsync(donorPetAudit);
        }

        public async Task<PaginatedResult<DonorPetAudit>> GetAllAsync(int pageNumber, int pageSize)
        {
            int totalItems = await genericRepository.TotalItems();
            string message = await IGenericService<DonorPetAudit>.ValidateNumber(totalItems,pageNumber, pageSize);
            if (String.IsNullOrEmpty(message))
            {
                throw new InvalidDataException("Donor pet audit model is null");
            }
            var donorPetAudits = await genericRepository.GetAllAsync(pageNumber, pageSize);
            if (donorPetAudits.Items == null)
            {
                throw new SqlNullValueException("Can't get list of donor pet audit");
            }
            return donorPetAudits;
        }

        public async Task<DonorPetAudit?> GetByIdAsync(int id)
        {
            if(id <= 0)
            {
                throw new InvalidDataException("Id must be greater than 0");
            }
            var r = await genericRepository.GetByIdAsync(id);
            if (r == null)
            {
                throw new SqlNotFilledException("Can't not find Donor pet audit with id = " + id);
            }
            return r;
        }
        public async Task<int> SoftDelete(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("Id must be greater than 0");
            }
            var donorPetAudit = await genericRepository.GetByIdAsync(id);

            if (donorPetAudit == null)
            {
                throw new ArgumentNullException("Can't not find Donor pet audit with id = " + id);
            }
            int affectedRows = await genericRepository.SoftDelete(donorPetAudit);
            if (affectedRows == 0)
            {
                throw new SqlNullValueException("Can't soft delete Donor pet audit");
            }
            return affectedRows;
        }

        public async Task<int?> UpdateAsync(int id, DonorPetAudit model)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("Id must be greater than 0");
            }
            var oldDonorPetAudit = await genericRepository.GetByIdAsync(id);

            if (oldDonorPetAudit == null)
            {
                throw new ArgumentNullException("Can't not find Updating Donor pet audit with id = " + id);
            }
            oldDonorPetAudit.LastDonation = model.LastDonation;
            oldDonorPetAudit.Version = model.Version;
            oldDonorPetAudit.NewTotalDonation = model.NewTotalDonation;
            oldDonorPetAudit.OldTotalDonation = model.OldTotalDonation;

            int affectedRows = await genericRepository.UpdateAsync(oldDonorPetAudit);
            if(affectedRows == 0)
            {
                throw new SqlNullValueException("Update Donor pet audit is failed");
            }
            return affectedRows;
        }
    }
}
