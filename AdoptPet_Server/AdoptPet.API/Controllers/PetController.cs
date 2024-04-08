
using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Location;
using AdoptPet.Application.DTOs.Pet;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IGenericRepository<Pet> genericRepository;
        public PetController(IGenericRepository<Pet> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        [HttpGet]
        [Route("get-pet-by-id/{id}")]
        public async Task<IActionResult> GetPetById(int id)
        {
            var r = await genericRepository.GetByIdAsync(id);
            return Ok(new Success<Pet> { Status = true, Messages = [], Data = r });
        }

        [HttpGet]
        [Route("get-all-pet")]
        public async Task<IActionResult> GetAllPet()
        {
            var pets = await genericRepository.GetAllAsync();
            return Ok(new Success<List<Pet>> { Status = true, Messages = [], Data = pets.ToList() });
        }

        [HttpPost]
        [Route("add-pet")]
        public async Task<IActionResult> AddPet(PetDto model)
        {
            Pet newPet = new Pet()
            {
                PetName = model.PetName,
                PetDescription = model.PetDescription,
                PetWeight = model.PetWeight,
                PetAge = model.PetAge,
                PetGender = model.PetGender,
                PetDesexed = model.PetDesexed,
                PetWormed = model.PetWormed,
                PetVaccined = model.PetVaccined,
                PetMicrochipped = model.PetMicrochipped,
                PetEntryDate = model.PetEntryDate
            };

            var r = await genericRepository.AddAsync(newPet);
            return Ok(new Success<Pet> { Status = true, Messages = [], Data = r });
        }

        [HttpPut]
        [Route("update-pet/{id}")]
        public async Task<IActionResult> UpdatePet(int id, PetDto model)
        {
            var oldPet = await genericRepository.GetByIdAsync(id);

            if (oldPet == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Pet not found"], Data = null });
            }
            oldPet.PetName = model.PetName;
            oldPet.PetDescription = model.PetDescription;
            oldPet.PetWeight = model.PetWeight;
            oldPet.PetAge = model.PetAge;
            oldPet.PetGender = model.PetGender;
            oldPet.PetDesexed = model.PetDesexed;
            oldPet.PetWormed = model.PetWormed;
            oldPet.PetVaccined = model.PetVaccined;
            oldPet.PetMicrochipped = model.PetMicrochipped;
            oldPet.PetEntryDate = model.PetEntryDate;

            /* cap nhat anhr */

            await genericRepository.UpdateAsync(oldPet);

            return Ok(new Success<PetDto> { Status = true, Messages = ["Update successfully"], Data = model });
        }

        [HttpDelete]
        [Route("delete-permanently-pet/{id}")] // 
        public async Task<IActionResult> DeletePermanentlyPet(int id)
        {
            var pet = await genericRepository.GetByIdAsync(id);

            if (pet == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Location not found"], Data = null });
            }
            await genericRepository.DeletePermanentlyAsync(pet);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }

        [HttpPut]
        [Route("soft-delete-pet/{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await genericRepository.GetByIdAsync(id);

            if (pet == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Pet not found"], Data = null });
            }
            await genericRepository.SoftDelete(pet);
            return Ok(new Success<object> { Status = true, Messages = ["Delete successfully"], Data = null });
        }
    }
}
