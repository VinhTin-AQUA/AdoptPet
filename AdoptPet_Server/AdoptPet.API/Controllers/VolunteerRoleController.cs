using AdoptPet.Application.DTOs;
using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        public async Task<IActionResult> GetVolunteerRoles()
        {
            var roles = await _volunteerRoleService.GetAllVolunteerRolesAsync();
            return Ok(new Success<List<VolunteerRole>>{ Status = true, Title = "", Messages = [], Data = roles });
        }

        [HttpGet]
        [Route("get-volunteerrole-by-id/{id}")]
        public async Task<IActionResult> GetVolunteerRole(int id)
        {
            var role = await _volunteerRoleService.GetVolunteerRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound(new Success<object> { Status = true, Title = "", Messages = ["vai trò không tìm thấy"], Data = null });
            }
            return Ok(new Success<VolunteerRole> { Status = true, Title = "", Messages = [], Data = role });
        }

        [HttpPost]
        [Route("add-volunteerrole")] 
        public async Task<IActionResult> AddVolunteerRole(VolunteerRole role)
        {
            var newRole = await _volunteerRoleService.AddVolunteerRoleAsync(role);
            return Ok(new Success<VolunteerRole> { Status = true, Title = "", Messages = [], Data = newRole });
        }

        [HttpPut]
        [Route("update-volunteerrole")]
        public async Task<IActionResult> UpdateVolunteerRole(VolunteerRole role)
        {
            var updated = await _volunteerRoleService.UpdateVolunteerRoleAsync(role);
            if (!updated)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = ["Có lỗi trong quá trình cập nhật. Xin vui lòng thử lại"], Data = null });
            }
            return Ok(new Success<VolunteerRole> { Status = true, Title = "", Messages = ["Cập nhật thành công"], Data = role });
        }

        [HttpDelete]
        [Route("delete-volunteerrole")]
        public async Task<IActionResult> DeleteVolunteerRole(int id)
        {
            var deleted = await _volunteerRoleService.DeleteVolunteerRoleAsync(id);
            if (!deleted)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = ["Có lỗi trong quá trình xóa. Xin vui lòng thử lại"], Data = null });
            }
            return Ok(new Success<int> { Status = true, Title = "", Messages = ["Xóa thành công"], Data = id });
        }

        [HttpPut]
        [Route("soft-delete-volunteerrole/{id}")]
        public async Task<IActionResult> SoftDeleteVolunteerRole(int id)
        {
            var deleted = await _volunteerRoleService.SoftDeleteVolunteerRoleAsync(id);
            if (!deleted)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = ["Có lỗi trong quá trình xóa. Xin vui lòng thử lại"], Data = null });
            }
            return Ok(new Success<int> { Status = true, Title = "", Messages = ["Xóa thành công"], Data = id });
        }
    }
}
