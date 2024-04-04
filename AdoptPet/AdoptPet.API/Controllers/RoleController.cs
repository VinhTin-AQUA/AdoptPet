using AdoptPet.Application.DTOs;
using AdoptPet.Application.Interfaces.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        [HttpPost]
        [Route("create-role")]
        public async Task<IActionResult> CreateRole(string rolename)
        {
            var r = await roleRepository.CreateRoleAsync(rolename);
            if (r.Succeeded == false)
            {
                return BadRequest(new Success<object> { Status = false, Messages = r.Errors.Select(e => e.Description).ToList() });
            }

            return Ok(new Success<object> { Status = true, Messages = [$"Create {rolename} role successfully"] });
        }


        [HttpDelete]
        [Route("delete-role")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var r = await roleRepository.DeleteRoleAsync(id);
            if (r.Succeeded == false)
            {
                return BadRequest(new Success<object> { Status = false, Messages = r.Errors.Select(e => e.Description).ToList() });
            }

            return Ok(new Success<object> { Status = true, Messages = [$"Delete role successfully"] });
        }
    }
}
