using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.Infrastructure.Repositories
{
    public class PetImageRepository : IPetImageRepository
    {
        private readonly AdoptPetDbContext _context;

        public PetImageRepository(AdoptPetDbContext context)
        {
            this._context = context;
        }

        public async Task<int> AddAsync(PetImage model)
        {
            _context.PetImages.Add(model);
            await _context.SaveChangesAsync();
            await _context.Entry(model).ReloadAsync();
            return model.Id;
        }

        public Task<int> AddManyImagesAsync(List<PetImage> images)
        {
            // add all images to the database
            _context.PetImages.AddRange(images);
            return _context.SaveChangesAsync(); // return affectedRows
        }

        public async Task DeletePermanentlyAsync(PetImage model)
        {
            _context.PetImages.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedResult<PetImage>> GetAllAsync(int pageNumber, int pageSize)
        {
            var images = await _context.PetImages
              .Skip((pageNumber - 1) * pageSize)
              .Take(pageSize)
              .ToListAsync();
            var totalItems = await TotalItems();
            return new PaginatedResult<PetImage>
            {
                Items = images,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<List<PetImage>> GetAllPetImageByPetId(int petId)
        {
            var images = await _context.PetImages
              .Where(i => i.PetId == petId && !i.IsDeleted)
              .ToListAsync();
            return images;
        }


        public async Task<PetImage?> GetByIdAsync(int id)
        {
            var r = await _context.PetImages
              .Where(i => i.Id == id && !i.IsDeleted)
              .FirstOrDefaultAsync();
            return r;
        }

        public Task<int> SoftDelete(PetImage model)
        {
            model.IsDeleted = true;
            _context.PetImages.Update(model);
            return _context.SaveChangesAsync();
        }

        public Task<int> TotalItems()
        {
            return _context.PetImages.CountAsync();
        }

        public async Task<int> UpdateAsync(PetImage model)
        {
            _context.PetImages.Update(model);
            return await _context.SaveChangesAsync();
        }

        public Task<int> UpdateManyImagesAsync(List<PetImage> images)
        {
            // update all images in the database
            _context.PetImages.UpdateRange(images);
            return _context.SaveChangesAsync(); // return affectedRows
        }
    }
}
