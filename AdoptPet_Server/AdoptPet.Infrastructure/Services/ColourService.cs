using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Colour;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;

namespace AdoptPet.Infrastructure.Services
{
    public class ColourService
    {
        private readonly IGenericRepository<Colour> genericRepository;

        public ColourService(IGenericRepository<Colour> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<Colour?> AddAsync(ColourDto model)
        {
            // kiểm tra model null
            if(model == null)
            {
                return null;
            }

            if(string.IsNullOrEmpty(model.ColourName) == true)
            {
                return null;
            }

            // tạo colour
            Colour newColour = new Colour()
            {
                ColourName = model.ColourName
            };
            var r = await genericRepository.AddAsync(newColour);
            return r;
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            var colour = await genericRepository.GetByIdAsync(id);

            // kiểm tra colour có tồn tại không
            if (colour == null)
            {
                return;
            }

            await genericRepository.DeletePermanentlyAsync(colour);
        }

        public async Task<ICollection<Colour>> GetAllAsync(int pageNumber, int pageSize)
        {
            var r = await genericRepository.GetAllAsync(pageNumber, pageSize);
            return r;
        }

        public async Task<Colour?> GetByIdAsync(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            return r;
        }

        public async Task SoftDelete(int id)
        {
            var colour = await genericRepository.GetByIdAsync(id);

            if (colour == null)
            {
                return;
            }
            await genericRepository.SoftDelete(colour.Id);
        }

        public async Task<Colour?> UpdateAsync(int id, ColourDto model)
        {
            // tìm color
            var oldColour = await genericRepository.GetByIdAsync(id);

            // kiểm tra tìm thấy không không
            if (oldColour == null)
            {
                return null;
            }
            oldColour.ColourName = model.ColourName; // gán lại màu đỏ

            /*
             oldColour.ColourName = "Black"
             */

            await genericRepository.UpdateAsync(oldColour);

            return oldColour;
        }
    }
}
