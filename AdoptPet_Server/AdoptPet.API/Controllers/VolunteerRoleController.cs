using AdoptPet.Application.DTOs;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using System.Data;
using System.Data.SqlTypes;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerRoleController : ControllerBase
    {
        private readonly VolunteerRoleService _volunteerRoleService;

        public VolunteerRoleController(VolunteerRoleService volunteerRoleService)
        {
            _volunteerRoleService = volunteerRoleService;
        }

        [HttpGet]
        [Route("get-all-volunteerrole")]
        public async Task<IActionResult> GetVolunteerRoles(int pageNumber = 1, int pageSize = 20)
        {
            try
            {
                var roles = await _volunteerRoleService.GetAllAsync(pageNumber, pageSize);
                return Ok(new Success<List<VolunteerRole>> { Status = true, Title = "", Messages = [], Data = roles.Items.ToList() });
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = [ex.Message], Data = null });
            }
            catch (SqlNullValueException ex)
            {
                return NotFound(new Success<object> { Status = true, Title = "", Messages = [ex.Message], Data = null });
            }
        }

        [HttpGet]
        [Route("get-volunteerrole-by-id/{id}")]
        public async Task<IActionResult> GetVolunteerRoleById(int id)
        {
            try {
                var role = await _volunteerRoleService.GetByIdAsync(id);
                return Ok(new Success<VolunteerRole> { Status = true, Title = "", Messages = [], Data = role });
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = [ex.Message], Data = null });
            }
            catch (SqlNullValueException ex)
            {
                return NotFound(new Success<object> { Status = true, Title = "", Messages = [ex.Message], Data = null });
            }
        }

        [HttpPost]
        [Route("add-volunteerrole")] 
        public async Task<IActionResult> AddVolunteerRole(VolunteerRole role)
        {
            try
            {
                var affectedRows = await _volunteerRoleService.AddAsync(role);
                return Ok(new Success<int> { Status = true, Title = "", Messages = [], Data = (int)affectedRows });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = [ex.Message], Data = null });
            }
            catch (SqlNullValueException ex)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = [ex.Message], Data = null });
            }
        }

        [HttpPut]
        [Route("update-volunteerrole")]
        public async Task<IActionResult> UpdateVolunteerRole(int Id, VolunteerRole role)
        {
            try
            {
                var updated = await _volunteerRoleService.UpdateAsync(Id, role);
                return Ok(new Success<VolunteerRole> { Status = true, Title = "", Messages = ["Cập nhật thành công"], Data = role });
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = [ex.Message], Data = null });
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(new Success<object> { Status = false, Title = "", Messages = [ex.Message], Data = null });
            }
            catch (SqlNullValueException ex)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = [ex.Message], Data = null });
            }
        }

        //[HttpDelete]
        //[Route("delete-volunteerrole")]
        //public async Task<IActionResult> DeleteVolunteerRole(int id)
        //{
        //    var deleted = await _volunteerRoleService.D(id);
        //    if (!deleted)
        //    {
        //        return BadRequest(new Success<object> { Status = false, Title = "", Messages = ["Có lỗi trong quá trình xóa. Xin vui lòng thử lại"], Data = null });
        //    }
        //    return Ok(new Success<int> { Status = true, Title = "", Messages = ["Xóa thành công"], Data = id });
        //}

        [HttpPut]
        [Route("soft-delete-volunteerrole/{id}")]
        public async Task<IActionResult> SoftDeleteVolunteerRole(int id)
        {
            try
            {
                var affectedRows = await _volunteerRoleService.SoftDelete(id);
                return Ok(new Success<int> { Status = true, Title = "", Messages = ["Xóa thành công"], Data = affectedRows });
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = [ex.Message], Data = null });
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(new Success<object> { Status = false, Title = "", Messages = [ex.Message], Data = null });
            }
            catch (SqlNullValueException ex)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = [ex.Message], Data = null });
            }
        }
    }
}
