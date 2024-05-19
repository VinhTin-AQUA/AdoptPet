
using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Location;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;

namespace AdoptPet.Infrastructure.Services
{
    public class LocationService : IGenericService<Location>
    {
        private readonly IGenericRepository<Location> genericRepository;

        public LocationService(IGenericRepository<Location> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        public async Task<int?> AddAsync(Location model)
        {
            if(model == null)
            {
                throw new Exception("Adding Location Model is null");
            }
            Location newLocation = new Location()
            {
                Street = model.Street,
                Wards = model.Wards,
                DistrictCity = model.DistrictCity,
                ProvinceCity = model.ProvinceCity
            };
            var r = await genericRepository.AddAsync(newLocation);
            if (r == 0)
            {
                throw new Exception("Adding location is failed");
            }
            return r;
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            var location = await genericRepository.GetByIdAsync(id);

            if (location == null)
            {
                throw new ArgumentNullException("Deleting Location model is null");
            }
            await genericRepository.DeletePermanentlyAsync(location);
        }

        public async Task<PaginatedResult<Location>> GetAllAsync(int pageNumber, int pageSize)
        {
            int totalItems = await genericRepository.TotalItems();
            string message = await IGenericService<Location>.ValidateNumber(totalItems, pageNumber, pageSize);
            if (String.IsNullOrEmpty(message))
            {
                throw new Exception(message);
            }

            var locations = await genericRepository.GetAllAsync(pageNumber, pageSize);
            if (locations.Items == null)
            {
                throw new ArgumentNullException("Can't get list of location");
            }

            return locations;
        }

        public async Task<Location?> GetByIdAsync(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            if (r == null)
            {
                throw new Exception("Location not found");
            }
            return r;
        }

        public async Task<int> SoftDelete(int id)
        {
            var location = await genericRepository.GetByIdAsync(id);

            if (location == null)
            {
                throw new Exception("Location not found");
            }
            int affectedRows = await genericRepository.SoftDelete(location);
            if (affectedRows == 0)
            {
                throw new Exception("Soft deleting location is failed");
            }
            return affectedRows;
        }
        public async Task<int?> UpdateAsync(int id, Location model)
        {
            var oldLoction = await genericRepository.GetByIdAsync(id);

            if (oldLoction == null)
            {
                throw new Exception("Updating location not found");
            }
            oldLoction.Street = model.Street;
            oldLoction.Wards = model.Wards;
            oldLoction.DistrictCity = model.DistrictCity;
            oldLoction.ProvinceCity = model.ProvinceCity;

            int affectedRows = await genericRepository.UpdateAsync(oldLoction);
            if(affectedRows == 0)
            {
                throw new Exception("Updating Location is failed");
            }
            return affectedRows;
        }
    }
}
