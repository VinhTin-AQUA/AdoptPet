using AdoptPet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly PetService petService;

        public PetController(PetService petService)
        {
            this.petService = petService;
        }

        [HttpGet]
        [Route("get-breeds")]
        public async Task<IActionResult> GetBreeds(string type)
        {
            var breeds = await petService.GetBreeds(type);

            return Ok(breeds);
        }

        [HttpGet]
        [Route("get-animals")]
        public async Task<IActionResult> GetAnimals(string type = "", string breed = "", string age = "", string size = "", string gender = "", string color = "", int page = 1, int limit = 10)
        {
            var r = await petService.GetAnimals(type, breed, age, size, gender, color, page, limit);
            return Ok(r);
        }

        [HttpGet]
        [Route("get-one")]
        public async Task<IActionResult> GetOne(string id)
        {
            var animal = await petService.GetOne(id);
            return Ok(animal);
        }
    }
}
