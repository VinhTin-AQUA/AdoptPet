using AdoptPet.Application.DTOs;
using AdoptPet.Application.DTOs.Volunteer;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Repositories;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly VolunteerService volunteerService;
        private readonly LocationService locationService;
        private readonly VolunteerRoleXVolunteerRepository volunteerRoleXVolunteerRepository;
        private readonly IAccountRepository accountRepository;

        public VolunteerController(VolunteerService volunteerService,
            LocationService locationService,
            VolunteerRoleXVolunteerRepository volunteerRoleXVolunteerRepository,
            IAccountRepository accountRepository)
        {
            this.volunteerService = volunteerService;
            this.locationService = locationService;
            this.volunteerRoleXVolunteerRepository = volunteerRoleXVolunteerRepository;
            this.accountRepository = accountRepository;
        }

        [HttpGet]
        [Route("get-all-volunteer")]
        public async Task<IActionResult> GetAllVolunteers(int pageNumber = 1, int pageSize = 20)
        {
            var r = await volunteerService.GetAllAsync(pageNumber, pageSize);

            var data = new List<object>();

            foreach(var v in r)
            {
                var volunteerRoles = await volunteerRoleXVolunteerRepository.GetVolunteerRolesByVolunteerId(v.Id);

                var d = new
                {
                    v.Id,
                    v.DateStart,
                    v.IsDeleted,
                    v.LocationId,
                    v.Location,
                    v.UserId,
                    Roles = volunteerRoles
                };
                data.Add(d);
            }

            return Ok(new Success<List<object>> { Status = true, Data = [.. data] });
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
            if (user == null)
            {
                return BadRequest(new Success<Volunteer> { Status = false, Title = "Email không hợp lệ" });
            }

            var newLocation = await locationService.AddAsync(model.Location);

            if (newLocation == null)
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
        public IActionResult UpdateVolunteer(Volunteer model)
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
