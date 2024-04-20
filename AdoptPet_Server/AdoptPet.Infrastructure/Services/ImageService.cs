

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
        public async Task<string> SaveImage(IFormFile file, string folderName, string id)
        {
            // đường dẫn đến thư mục ~/wwwroot/images
            var rootImageFolder = System.IO.Path.Combine(webHost.WebRootPath, "Images");
            string folderOfImage = System.IO.Path.Combine(rootImageFolder, folderName);
            
            if(Directory.Exists(folderOfImage) == false)
            {
                Directory.CreateDirectory(folderOfImage);
            }

            // xóa ảnh cũ
            //DirectoryInfo di = new DirectoryInfo(folderOfImage);
            //foreach (FileInfo oldImg in di.GetFiles())
            //{
            //    oldImg.Delete();
            //}

            string fileName = file.FileName;
            string fileExtension = System.IO.Path.GetExtension(fileName);
            string nameExrypted = EncyptFileName(fileName, id) + "." + fileExtension;
            string filePath = System.IO.Path.Combine(folderOfImage, nameExrypted);
            
            //if (System.IO.File.Exists(filePath))
            //{
            //    System.IO.File.Delete(filePath);
            //}

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }

        private string EncyptFileName(string fileName, string id)
        {
            string inputValue = fileName + id;
            // băm
            var inputBytes = Encoding.UTF8.GetBytes(inputValue);
            var inputHash = SHA256.HashData(inputBytes);
            string hexString = Convert.ToHexString(inputHash);
            return hexString;
        }
    }
}
