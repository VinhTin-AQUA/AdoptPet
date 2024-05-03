

using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;

namespace AdoptPet.Infrastructure.Services
{
    public class VolunteerService
    {
        private readonly IGenericRepository<Volunteer> genericRepository;

        public VolunteerService(IGenericRepository<Volunteer> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<Volunteer?> AddAsync(Volunteer model)
        {
            if (model == null)
            {
                return null;
            }
            await genericRepository.AddAsync(model);
            return model;
        }

        public async Task DeletePermanentlyAsync(Volunteer model)
        {
            if (model == null)
            {
                return;
            }
            await genericRepository.DeletePermanentlyAsync(model);
        }

        public async Task<ICollection<Volunteer>> GetAllAsync(int pageNumber, int pageSize)
        {
            var r = await genericRepository.GetAllAsync(pageNumber, pageSize);
            return r.Items!;
        }

        public async Task<Volunteer?> GetByIdAsync(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            return r;
        }

        public async Task SoftDelete(Volunteer model)
        {
            if (model == null)
            {
                return;
            }
            await genericRepository.SoftDelete(model.Id);
        }

        public async Task UpdateAsync(Volunteer model)
        {
            if (model == null)
            {
                return;
            }
            await genericRepository.UpdateAsync(model);
        }
    }
}
