
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using System.Data.SqlTypes;

namespace AdoptPet.Infrastructure.Services
{
    
    public class DonorService : IGenericService<Donor>
    {
        private readonly IGenericRepository<Donor> genericRepository;

        public DonorService(IGenericRepository<Donor> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        public async Task<int?> AddAsync(Donor model)
        {
            if(model == null)
            {
                throw new ArgumentNullException("Adding Donor Model is null");
            }
            if(string.IsNullOrEmpty(model.Name) == true)
            {
                throw new ArgumentNullException("Donor Name is null");
            }
            Donor newDonor = new Donor()
            {
                Name = model.Name,
                TotalDonation = model.TotalDonation

            };

            var r = await genericRepository.AddAsync(newDonor);
            if (r == 0)
            {
                throw new SqlNullValueException("Adding donor is failed");
            }
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

        public async Task<PaginatedResult<Donor>> GetAllAsync(int pageNumber, int pageSize)
        {
            int totalItems = await genericRepository.TotalItems();
            string message = await IGenericService<Donor>.ValidateNumber(totalItems, pageNumber, pageSize);
            if (String.IsNullOrEmpty(message))
            {
                throw new InvalidDataException(message);
            }
            var donors = await genericRepository.GetAllAsync(pageNumber, pageSize);
            if (donors.Items == null)
            {
                throw new SqlNullValueException("Can't get list of donor");
            }
            return donors;
        }

        public async Task<Donor?> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("Id must be greater than 0");
            }
            var r = await genericRepository.GetByIdAsync(id);
            if (r == null)
            {
                throw new SqlNullValueException("Donor not found");
            }
            return r;
        }

        public async Task<int> SoftDelete(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("Id must be greater than 0");
            }
            var donor = await genericRepository.GetByIdAsync(id);

            if (donor == null)
            {
                throw new ArgumentNullException("Donor not found");
            }
            int affectedRows = await genericRepository.SoftDelete(donor);
            if (affectedRows == 0)
            {
                throw new SqlNullValueException("Can't soft delete Donor");
            }
            return affectedRows;
        }

        public async Task<int?> UpdateAsync(int id, Donor model)
        {
            if(id<=0)
            {
                throw new InvalidDataException("Id must be greater than 0");
            }
            var oldDonor = await genericRepository.GetByIdAsync(id);

            if (oldDonor == null)
            {
                throw new ArgumentNullException("Updating Donor not found");
            }
            oldDonor.Name = model.Name;
            oldDonor.TotalDonation = model.TotalDonation;

            int affectedRows = await genericRepository.UpdateAsync(oldDonor);
            if(affectedRows == 0)
            {
                throw new SqlNullValueException("Can't update Donor");
            }
            return affectedRows;
        }
    }
}
