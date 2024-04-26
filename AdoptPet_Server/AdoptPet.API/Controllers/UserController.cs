using AdoptPet.Application.DTOs;
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
        private readonly IAccountRepository accountRepository;
        private readonly IRoleRepository roleRepository;

        public UserController(
            IUserRepository userRepository, 
            IAccountRepository accountRepository,
            IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.accountRepository = accountRepository;
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
                    Id = u.Id,
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

        [HttpPut]
        [Route("lock-user/{userId}")]
        public async Task<IActionResult> LockUser(string userId)
        {
            if (string.IsNullOrEmpty(userId) == true)
            {
                return BadRequest();
            }

            var userExists = await accountRepository.GetUserByIdAsync(userId);

            if(userExists== null)
            {
                return BadRequest(new Success<object> { Title = "User not found", Messages = [], Data = null, Status = false });
            }
            var r = await userRepository.LockUser(userExists);

            if(r.Succeeded == false)
            {
                List<string> errors = r.Errors
                    .Select(r => r.Description)
                    .ToList();
                return BadRequest(new Success<object> { Title = "Somethong error", Messages = [], Data = errors, Status = false });
            }

            return Ok(new Success<object> { Title = "Lock successfully", Messages = [], Data = userExists.LockoutEnd, Status = true });
        }

        [HttpPut]
        [Route("unlock-user/{userId}")]
        public async Task<IActionResult> UnLockUser(string userId)
        {
            if (string.IsNullOrEmpty(userId) == true)
            {
                return BadRequest();
            }

            var userExists = await accountRepository.GetUserByIdAsync(userId);

            if (userExists == null)
            {
                return BadRequest(new Success<object> { Title = "User not found", Messages = [], Data = null, Status = false });
            }
            var r = await userRepository.UnLockUser(userExists);

            if (r.Succeeded == false)
            {
                return BadRequest(new Success<object> { Title = "Somethong error", Messages = [], Data = null, Status = false });
            }

            return Ok(new Success<object> { Title = "Unlock successfully", Messages = [], Data = null, Status = true });
        }
    }
}
