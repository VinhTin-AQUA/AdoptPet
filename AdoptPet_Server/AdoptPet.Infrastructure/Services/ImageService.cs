

using AdoptPet.Application.Interfaces.IService;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

namespace AdoptPet.Infrastructure.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment webHost;
        //private readonly string FileUpload = "FileUploads";

        public ImageService(IWebHostEnvironment webHost)
        {
            this.webHost = webHost;
        }

        /*
         folderName:
            - Breeds
            - Pets
         */
        // validate image extension
        public bool ValidateImageExtension(string fileName)
        {
            string[] validExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
            string extension = System.IO.Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(extension) || Array.IndexOf(validExtensions, extension.ToLower()) == -1)
            {
                return false;
            }
            return true;
        }
        // Validate Extension for many images: return false if any image is invalid and show which image file name is invalid
        public bool ValidateImagesExtension(List<IFormFile> images, out string invalidImageFileName)
        {
            invalidImageFileName = "";
            foreach (var image in images)
            {
                if (!ValidateImageExtension(image.FileName))
                {
                    invalidImageFileName += image.FileName ;
                    return false;
                }
            }

            return true;
        }
        public async Task<string> SaveImageAsync(String rootImagePath, String entityName, IFormFile imageFile)
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
        // Save many images
        public async Task<List<string>> SaveImagesAsync(String rootImagePath, String entityName, List<IFormFile> images)
        {
            List<string> imageNames = new List<string>();
            foreach (var image in images)
            {
                imageNames.Add(await SaveImageAsync(rootImagePath, entityName, image));
            }
            return imageNames;
        }
        public void DeleteOldImage(String rootImagePath, String entityName, string oldFileName)
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
