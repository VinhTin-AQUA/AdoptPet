using Microsoft.AspNetCore.Http;

namespace AdoptPet.Application.Interfaces.IService
{
    public interface IImageService
    {
        Task<string> SaveImage(IFormFile file, string folderName, string id);
    }
}
