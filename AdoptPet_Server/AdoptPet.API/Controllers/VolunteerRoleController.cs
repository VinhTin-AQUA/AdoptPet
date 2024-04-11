using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(roles);
        }

        [HttpGet]
        [Route("get-volunteerrole-by-id/{id}")]
        public async Task<IActionResult> GetVolunteerRole(int id)
        {
            var role = await _volunteerRoleService.GetVolunteerRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        [Route("add-volunteerrole")]
        public async Task<IActionResult> AddVolunteerRole(VolunteerRole role)
        {
            var newRole = await _volunteerRoleService.AddVolunteerRoleAsync(role);
            return CreatedAtAction(nameof(GetVolunteerRole), new { id = newRole.Id }, newRole);
        }

        [HttpPut]
        [Route("update-volunteerrole")]
        public async Task<IActionResult> UpdateVolunteerRole(VolunteerRole role)
        {
            var updated = await _volunteerRoleService.UpdateVolunteerRoleAsync(role);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("delete-volunteerrole")]
        public async Task<IActionResult> DeleteVolunteerRole(int id)
        {
            var deleted = await _volunteerRoleService.DeleteVolunteerRoleAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("soft-delete-volunteerrole")]
        public async Task<IActionResult> SoftDeleteVolunteerRole(int id)
        {
            var deleted = await _volunteerRoleService.SoftDeleteVolunteerRoleAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
