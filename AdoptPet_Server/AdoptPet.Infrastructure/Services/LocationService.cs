
using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Location;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;

namespace AdoptPet.Infrastructure.Services
{
    public class LocationService
    {
        private readonly IGenericRepository<Location> genericRepository;
        public LocationService(IGenericRepository<Location> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        public async Task<int?> AddAsync(LocationDto model)
        {
            if(model == null)
            {
                return null;
            }
            Location newLocation = new Location()
            {
                Street = model.Street,
                Wards = model.Wards,
                DistrictCity = model.DistrictCity,
                ProvinceCity = model.ProvinceCity
            };

            var r = await genericRepository.AddAsync(newLocation);
            return r;
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            var location = await genericRepository.GetByIdAsync(id);

            if (location == null)
            {
                return;
            }
            await genericRepository.DeletePermanentlyAsync(location);
        }

        public async Task<PaginatedResult<Location>> GetAllAsync(int pageNumber, int pageSize)
        {
            var locations = await genericRepository.GetAllAsync(pageNumber, pageSize);
            return locations;
        }

        public async Task<Location?> GetByIdAsync(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            return r;
        }

        public async Task SoftDelete(int id)
        {
            var location = await genericRepository.GetByIdAsync(id);

            if (location == null)
            {
                return;
            }
            await genericRepository.SoftDelete(id);
        }
        public async Task<Location?> UpdateAsync(int id, LocationDto model)
        {
            var oldLoction = await genericRepository.GetByIdAsync(id);

            if (oldLoction == null)
            {
                return null;
            }
            oldLoction.Street = model.Street;
            oldLoction.Wards = model.Wards;
            oldLoction.DistrictCity = model.DistrictCity;
            oldLoction.ProvinceCity = model.ProvinceCity;

            await genericRepository.UpdateAsync(oldLoction);
            return oldLoction;
        }
    }
}
