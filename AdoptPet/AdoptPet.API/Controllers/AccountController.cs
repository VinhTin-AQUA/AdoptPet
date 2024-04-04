using AdoptPet.Application.DTOs.Account;
using AdoptPet.Application.DTOs;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using AdoptPet.Application.Interfaces;

namespace AdoptPet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;
        private readonly IJwtService jwtService;
        private readonly IRoleRepository roleRepository;
        private readonly IEmailSenderService emailSenderService; // thực hiện gửi mail

        public AccountController(IAccountRepository accountRepository, IJwtService jwtService,
            IRoleRepository roleRepository, IEmailSenderService emailSenderService)
        {
            this.accountRepository = accountRepository;
            this.jwtService = jwtService;
            this.roleRepository = roleRepository;
            this.emailSenderService = emailSenderService;
        }

        [HttpPost]
        [Route("sign-up")]
        public async Task<IActionResult> SignUp(SignUpDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var userExits = await accountRepository.GetUserByEmailAsync(model.Email);

            if (userExits != null)
            {
                Success<object> error = new()
                {
                    Status = false,
                    Messages = ["Email already taken. Please choose another email"]
                };
                return BadRequest(error);
            }

            var newUser = new AppUser
            {
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber,
            };

            var r = await accountRepository.SignUpAsync(newUser, model.Password);
            if (r.Succeeded == false)
            {
                Success<object> error = new()
                {
                    Status = false,
                    Messages = r.Errors.Select(e => e.Description).ToList()
                };
                return BadRequest(error);
            }

            // add role
            await roleRepository.AddRoleRoUserAsync(newUser, "User");

            // send mail
            string token = await accountRepository.GenerateEmailConfirmationTokenAsync(newUser);
            if (await emailSenderService.SendEmailConfirmAsync(newUser, token) == true)
            {
                return Ok(new JsonResult(new { title = "Verify Your Email", message = "Please check your email to confirm email to verify your account." }));
            }

            return Ok(new Success<object> { Status = true, Messages = ["SignIn successfully"] });
        }

        [HttpPost]
        [Route("sign-in")]
        public async Task<IActionResult> SignIn(SignInDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var user = await accountRepository.GetUserByEmailAsync(model.Email);

            if (user == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Incorrect email or password"] });
            }

            var r = await accountRepository.SignInAsync(user, model.Password);

            if (r.IsLockedOut == true)
            {
                return BadRequest(new Success<object> { Status = false, Messages = [$"You has been locked. Login after {user.LockoutEnd}"] });
            }

            if (r.Succeeded == false)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Incorrect email or password"] });
            }
            var userDto = new AccountDto
            {
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber!,
                Token = await jwtService.CreateJWT(user)
            };

            return Ok(new Success<AccountDto> { Status = true, Messages = ["Login successfully"], Data = userDto });
        }

        // phương thức này bấm ở client để gửi đến server
        [HttpPut]
        [Route("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailDto confirm)
        {
            var user = await accountRepository.GetUserByEmailAsync(confirm.Email);
            if (user == null)
            {

                return BadRequest(new Success<object> { Status = false, Messages = ["This email has not been registered."] });
            }

            if (user.EmailConfirmed == true)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Your email was confirm before. Please login your account"] });
            }

            try
            {
                var decodedTokenBytes = WebEncoders.Base64UrlDecode(confirm.Token);
                var decodedToken = Encoding.UTF8.GetString(decodedTokenBytes);
                var result = await accountRepository.ConfirmEmailAsync(user, decodedToken);

                if (result.Succeeded == true)
                {
                    return Ok(new Success<object> { Status = true, Messages = ["Your email addres is comfirmed. You can login now."] });
                }
                return BadRequest(new Success<object> { Status = false, Messages = ["Invalid token. Try again."] });
            }
            catch (Exception)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Invalid token. Try again."] });
            }
        }

        [HttpGet]
        [Route("resend-confirmation-email/{email}")]
        public async Task<IActionResult> ResendConfirmationEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Incorrect Email or Password"] });
            }

            var user = await accountRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Incorrect Email or Password"] });
            }

            if (user.EmailConfirmed == true)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Your email is conformed before. You can login now."] });
            }

            try
            {
                string token = await accountRepository.GenerateEmailConfirmationTokenAsync(user);
                if (await emailSenderService.SendEmailConfirmAsync(user, token))
                {
                    return Ok(new Success<object> { Status = true, Messages = ["Please check your email to confirm email to verify your account."] });
                }
                return BadRequest(new Success<object> { Status = false, Messages = ["Fail to send email confirmation. Please try again."] });
            }
            catch (Exception)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Fail to send email confirmation. Please try again."] });
            }
        }

        // gửi email reset password đến email
        [HttpGet]
        [Route("send-email-reset-password/{email}")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Email is incorrect"] });
            }

            var user = await accountRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Email is incorrect"] });
            }

            try
            {
                string token = await accountRepository.GeneratePasswordResetTokenAsync(user);
                if (await emailSenderService.SendForgotPasswordEmail(user, token))
                {
                    return Ok(new Success<object> { Status = true, Messages = ["Forgot password email sent. Please check your email. "] });
                }
                return BadRequest(new Success<object> { Status = false, Messages = ["Failed to sent email. Please contact again."] });
            }
            catch (Exception)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Failed to sent email. Please contact again."] });
            }
        }

        // sau lick link email thì tiến hành đổi mật khẩu
        [HttpPut]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            if (model == null)
            {
                return BadRequest(ModelState);
            }
            var user = await accountRepository.GetUserByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Email is incorrect"] });
            }

            try
            {
                var decodedTokenBytes = WebEncoders.Base64UrlDecode(model.Token);
                var decodedToken = Encoding.UTF8.GetString(decodedTokenBytes);
                var result = await accountRepository.ResetPasswordAsync(user, decodedToken, model.Password);

                if (result.Succeeded == true)
                {
                    return Ok(new Success<object> { Status = true, Messages = ["Password has been reseted. Your password is reseted. You can login now."] });
                }
                return BadRequest(new Success<object> { Status = false, Messages = ["Invalid token. Try again."] });
            }
            catch (Exception)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Invalid token. Try again."] });
            }
        }

        [HttpPut]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            if (model == null)
            {
                return BadRequest(ModelState);
            }

            //if(ModelState.IsValid == false)
            //{
            //    return BadRequest(new Success { Status = false, Messages = ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage).ToList() });
            //}

            var user = await accountRepository.GetUserByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest(new Success<object> { Status = false, Messages = ["Incorrect email or password"] });
            }
            var r = await accountRepository.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (r.Succeeded == false)
            {
                return BadRequest(new Success<object> { Status = false, Messages = r.Errors.Select(e => e.Description).ToList() });
            }

            return Ok(new Success<object> { Status = true, Messages = ["Password change successfully"] });
        }
    }
}
