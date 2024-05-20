

using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using System.Data.SqlTypes;

namespace AdoptPet.Infrastructure.Services
{
    public class VolunteerService : IGenericService<Volunteer>
    {
        private readonly IGenericRepository<Volunteer> genericRepository;

        public VolunteerService(IGenericRepository<Volunteer> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<int?> AddAsync(Volunteer model)
        {
            if (model == null)
            {
                throw new ArgumentNullException($"Adding Model is null");
            }
            int affectedRows =await genericRepository.AddAsync(model);
            if (affectedRows == 0)
            {
                throw new SqlNullValueException($"Adding volunteer is failed");
            }
            return affectedRows;
        }

        public async Task DeletePermanentlyAsync(Volunteer model)
        {
            if (model == null)
            {
                return;
            }
            await genericRepository.DeletePermanentlyAsync(model);
        }


        public async Task<PaginatedResult<Volunteer>> GetAllAsync(int pageNumber, int pageSize)
        {
            int totalItems = await genericRepository.TotalItems();
            string message = await IGenericService<Volunteer>.ValidateNumber(totalItems, pageNumber, pageSize);
            if (String.IsNullOrEmpty(message))
            {
                throw new InvalidDataException(message);
            }

            var r = await genericRepository.GetAllAsync(pageNumber, pageSize);
            if (r == null)
            {
                throw new SqlNullValueException($"Volunteer list is empty");
            }
            return r;
        }

        public async Task<Volunteer?> GetByIdAsync(int id)
        {

            if (id <= 0)
            {
                throw new InvalidDataException($"Id must be greater than 0");
            }
            var r = await genericRepository.GetByIdAsync(id);
            if (r == null)
            {
                throw new SqlNullValueException($"Volunteer with id {id} not found.");
            }
            return r;
        }

        public async Task<int> SoftDelete(int Id)
        {
            if(Id <= 0)
            {
                throw new InvalidDataException($"Id must be greater than 0");
            }
            var volunteer = await genericRepository.GetByIdAsync(Id);
            if (volunteer == null)
            {
                throw new ArgumentNullException($"Volunteer with id {Id} not found.");
            }
            int affectedRows = await genericRepository.SoftDelete(volunteer);
            if (affectedRows == 0)
            {
                throw new SqlNullValueException($"Deleting volunteer is failed");
            }
            return affectedRows;
        }

        public async Task<int?> UpdateAsync(int id, Volunteer model)
        {
            if (id <= 0)
            {
                throw new InvalidDataException($"Id must be greater than 0");
            }
            if (model == null)
            {
                throw new ArgumentNullException($"Sent volunteer model isn't received");
            }
            var volunteer = await genericRepository.GetByIdAsync(id);
            if (volunteer == null)
            {
                throw new ArgumentNullException($"Volunteer with id {id} not found.");
            }
            volunteer.DateStart = model.DateStart;
            volunteer.LocationId = model.LocationId;

            int affectedRows = await genericRepository.UpdateAsync(volunteer);
            if (affectedRows == 0)
            {
                throw new SqlNullValueException($"Updating volunteer is failed");
            }
            return affectedRows;
        }
    }
}
