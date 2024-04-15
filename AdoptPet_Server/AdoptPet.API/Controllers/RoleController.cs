using AdoptPet.Application.DTOs;
using AdoptPet.Application.Interfaces.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        [HttpPost]
        [Route("create-role")]
        public async Task<IActionResult> CreateRole([FromForm]string roleName)
        {
            var checkRoleExists = await roleRepository.RoleExits(roleName);
            if(checkRoleExists == true)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = [$"{roleName} đã tồn tại"], Data = null });
            }

            var newRole = new IdentityRole(roleName);


            var r = await roleRepository.CreateRoleAsync(newRole);
            if (r.Succeeded == false)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = r.Errors.Select(e => e.Description).ToList() });
            }

            return Ok(new Success<object> { Status = true, Title = "", Messages = [$"Create {roleName} role successfully"], Data = new { Id = newRole.Id, RoleName = newRole.Name } });
        }


        [HttpDelete]
        [Route("delete-role/{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var r = await roleRepository.DeleteRoleAsync(id);
            if (r.Succeeded == false)
            {
                return BadRequest(new Success<object> { Status = false, Title = "", Messages = r.Errors.Select(e => e.Description).ToList() });
            }

            return Ok(new Success<object> { Status = true, Title = "", Messages = [$"Delete role successfully"] });
        }

        [HttpGet]
        [Route("get-all-roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await roleRepository.GetAllRoles();
            var _roles = roles.Select(r => new
            {
                Id = r.Id,
                RoleName = r.Name
            }).ToList();
            return Ok(new Success<object> { Status = true, Title = "", Messages = [], Data = _roles });
        }
    }
}
