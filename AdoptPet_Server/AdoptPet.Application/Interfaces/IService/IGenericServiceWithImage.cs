using AdoptPet.Application.DTOs;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Http;

namespace AdoptPet.Application.Interfaces.IService
{
    public interface IGenericServiceWithImage<T> : IGenericService<T> where T : class
    {
        public Task<int?> AddAsync(T model, IFormFile formFile);
        public Task<int?> UpdateAsync(int id, Breed model, IFormFile formFile);
        protected static bool ValidateImageExtension(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();
            return new string[] { ".jpg", ".jpeg", ".png" }.Contains(extension);
        }
        protected static async Task<string> SaveImageAsync(String rootImagePath, String entityName, IFormFile imageFile)
        {
            string uploadsFolder = Path.Combine(rootImagePath, entityName);
            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return uniqueFileName;
        }
        protected static void DeleteOldImage(String rootImagePath, String entityName, string oldFileName)
        {
            if (!string.IsNullOrEmpty(oldFileName))
            {
                var imagePath = Path.Combine(rootImagePath, entityName, oldFileName);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
        }

    }
}
