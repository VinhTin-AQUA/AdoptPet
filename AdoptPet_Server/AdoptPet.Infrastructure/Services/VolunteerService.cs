

using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;

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
                throw new InvalidOperationException($"Adding volunteer is failed");
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
            var r = await genericRepository.GetAllAsync(pageNumber, pageSize);
            return r;
        }

        public async Task<Volunteer?> GetByIdAsync(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            return r;
        }

        public async Task<int?> SoftDelete(int Id)
        {
            var volunteer = await genericRepository.GetByIdAsync(Id);
            if (volunteer == null)
            {
                throw new InvalidOperationException($"Volunteer with id {Id} not found.");
            }
            int affectedRows = await genericRepository.SoftDelete(volunteer);
            if (affectedRows == 0)
            {
                throw new InvalidOperationException($"Deleting volunteer is failed");
            }
            return affectedRows;
        }

        public async Task<int?> UpdateAsync(int id, Volunteer model)
        {
            if (model == null)
            {
                throw new ArgumentNullException($"Sent volunteer model isn't received");
            }
            var volunteer = await genericRepository.GetByIdAsync(id);
            if (volunteer == null)
            {
                throw new InvalidOperationException($"Volunteer with id {id} not found.");
            }
            volunteer.DateStart = model.DateStart;
            volunteer.LocationId = model.LocationId;

            int affectedRows = await genericRepository.UpdateAsync(volunteer);
            if (affectedRows == 0)
            {
                throw new InvalidOperationException($"Updating volunteer is failed");
            }
            return affectedRows;
        }
    }
}
