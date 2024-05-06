using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Volunteer;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly VolunteerService volunteerService;
        private readonly LocationService locationService;
        private readonly IAccountRepository accountRepository;

        public VolunteerController(VolunteerService volunteerService, 
            LocationService locationService,
            IAccountRepository accountRepository)
        {
            this.volunteerService = volunteerService;
            this.locationService = locationService;
            this.accountRepository = accountRepository;
        }

        [HttpGet]
        [Route("get-all-volunteer/pageNumber/{pageNumber}/pageSize/{pageSize}")]
        public async Task<IActionResult> GetAllVolunteers(int pageNumber, int pageSize)
        {
            var r = await volunteerService.GetAllAsync(pageNumber, pageSize);
            return Ok(new Success<List<Volunteer>> { Status = true, Data = r.Items.ToList() });
        }

        [HttpGet]
        [Route("get-volunteer/{id}")]
        public async Task<IActionResult> GetVolunteerById(int id)
        {
            var r = await volunteerService.GetByIdAsync(id);
            if (r == null)
            {
                return Ok(new Success<Volunteer> { Status = false, Data = r });
            }

            return Ok(new Success<Volunteer> { Status = true, Data = r });
        }

        [HttpPost]
        [Route("add-volunteer")]
        public async Task<IActionResult> AddVolunteer(VolunteerDto model)
        {
            var user = await accountRepository.GetUserByEmailAsync(model.UserEmail);
            if(user == null)
            {
                return BadRequest(new Success<Volunteer> { Status = false, Title = "Email không hợp lệ" });
            }

            var newLocation = await locationService.AddAsync(model.Location);

            if(newLocation == null)
            {
                return BadRequest(new Success<Volunteer> { Status = false, Title = "Có lỗi xảy ra. Vui lòng thử lại" });
            }

            Volunteer newVolunteer = new()
            {
                DateStart = DateTime.Now,
                IsDeleted = false,
                LocationId = (int)newLocation,
                UserId = user.Id,
            };

            var r = await volunteerService.AddAsync(newVolunteer);
            if (r == null)
            {
                return BadRequest(new Success<Volunteer> { Status = false, Title = "Có lỗi xảy ra. Vui lòng thử lại" });
            }
            return Ok(new Success<Volunteer> { Status = true, Data = r });
        }

        [HttpPut]
        [Route("update-volunteer")]
        public async Task<IActionResult> UpdateVolunteer(Volunteer model)
        {
            //var oldVolunteer = await volunteerService.GetByIdAsync(model.Id);

            //if (oldVolunteer == null)
            //{
            //    return Ok(new Success<Volunteer> { Status = false, Title = "Volunteer not found" });
            //}


            //await volunteerService.UpdateAsync(oldVolunteer);
            return Ok();
        }

        //[HttpDelete]
        //[Route("soft-delete/{id}")]
        //public async Task<IActionResult> SoftDelete(int id)
        //{
            
        //}



    }
}
