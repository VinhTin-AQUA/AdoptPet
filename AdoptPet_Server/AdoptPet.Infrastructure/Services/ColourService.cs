using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Colour;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;

namespace AdoptPet.Infrastructure.Services
{
    public class ColourService: IGenericService<Colour>
    {
        private readonly IGenericRepository<Colour> genericRepository;

        public ColourService(IGenericRepository<Colour> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<int?> AddAsync(Colour model)
        {
            if(model == null)
            {
                throw new Exception("Model is null");
            }

            if(string.IsNullOrEmpty(model.ColourName) == true)
            {
                throw new Exception("ColourName is null");
            }

            // tạo colour
            Colour newColour = new Colour()
            {
                ColourName = model.ColourName
            };
            var r = await genericRepository.AddAsync(newColour);
            if(r == 0)
            {
                throw new Exception("Adding colour is failed");
            }
            return r;
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            var colour = await genericRepository.GetByIdAsync(id);

            // kiểm tra colour có tồn tại không
            if (colour == null)
            {
                throw new Exception("Deleting colour is not exists");
            }

            await genericRepository.DeletePermanentlyAsync(colour);
        }

        public async Task<PaginatedResult<Colour>> GetAllAsync(int pageNumber, int pageSize)
        {
            int totalItems = await genericRepository.TotalItems();
            String message = await IGenericService<Colour>.ValidateNumber(totalItems,pageNumber, pageSize);
            if (String.IsNullOrEmpty(message))
            {
                throw new Exception(message);
            }

            var r = await genericRepository.GetAllAsync(pageNumber, pageSize);
            if (r.Items == null)
            {
                throw new Exception("Can't get list of colour");
            }
            return r;
        }


        public async Task<Colour?> GetByIdAsync(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            if(r == null)
            {
                throw new Exception("Colour not found");
            }
            return r;
        }

        public async Task<int> SoftDelete(int id)
        {
            var colour = await genericRepository.GetByIdAsync(id);

            if (colour == null)
            {
                throw new Exception("Deleting colour is not exists");
            }
            int affectedRows = await genericRepository.SoftDelete(colour);
            if (affectedRows == 0)
            {
                throw new Exception("Deleting colour is failed");
            }
            return affectedRows;
        }

        public async Task<int?> UpdateAsync(int id, Colour model)
        {
            // tìm color
            var oldColour = await genericRepository.GetByIdAsync(id);

            // kiểm tra tìm thấy không không
            if (oldColour == null)
            {
                throw new Exception("Updating colour is not found");
            }
            oldColour.ColourName = model.ColourName; // gán lại màu đỏ

            /*
             oldColour.ColourName = "Black"
             */

            int affectedRows = await genericRepository.UpdateAsync(oldColour);
            if(affectedRows == 0)
            {
                throw new Exception("Updating colour is failed");
            }
            return affectedRows;
        }
    }
}
