using Microsoft.AspNetCore.Http;

namespace AdoptPet.Application.Interfaces.IService
{
    public interface IImageService
    {
        Task<string> SaveImageAsync(String rootImagePath, String entityName, IFormFile imageFile);
        public bool ValidateImagesExtension(List<IFormFile> images, out string invalidImageFileName);
        public void DeleteOldImage(String rootImagePath, String entityName, string oldFileName);
        public Task<List<string>> SaveImagesAsync(String rootImagePath, String entityName, List<IFormFile> images);
        public bool ValidateImageExtension(string fileName);
    }
}
