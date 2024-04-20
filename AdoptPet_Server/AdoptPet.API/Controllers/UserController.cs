using AdoptPet.Application.DTOs.User;
using AdoptPet.Application.Interfaces.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public UserController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        [HttpGet]
        [Route("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userRepository.GetAllUsers();
            var r = users.Select(u =>
            {
                return new UserDto
                {
                    Email = u.Email!,
                    PhoneNumber = u.PhoneNumber!,
                    EmailConfirmed = u.EmailConfirmed,
                    PhoneNumberConfirmed = u.PhoneNumberConfirmed,
                    LockoutEnd = u.LockoutEnd,
                    LastName = u.LastName,
                    FirstName = u.FirstName,
                };
            }).ToList();

            for (int i = 0; i < r.Count(); i++)
            {
                var roles = await roleRepository.GetRoleOfUser(users[i]);
                r[i].Roles = roles;
            }
            return Ok(r);
        }

        [HttpGet]
        [Route("search-user-by-name")]
        public async Task<IActionResult> SearchUserByName(string name)
        {
            var users = await userRepository.SearchUserByName(name);
            var r = users.Select(u => new UserDto
            {
                Email = u.Email!,
                PhoneNumber = u.PhoneNumber!,
                EmailConfirmed = u.EmailConfirmed,
                PhoneNumberConfirmed = u.PhoneNumberConfirmed,
                LockoutEnd = u.LockoutEnd,
            }).ToList();
            return Ok(r);
        }
    }
}
