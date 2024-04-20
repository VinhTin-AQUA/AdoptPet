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
                    Title = "Email đã được đăng ký",
                    Status = false,
                    Messages = ["Email này đã được đăng ký. Vui lòng chọn một email khác."]
                };
                return BadRequest(error);
            }

            var newUser = new AppUser
            {
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            var r = await accountRepository.SignUpAsync(newUser, model.Password);
            if (r.Succeeded == false)
            {
                Success<object> error = new()
                {
                    Title = "Có lỗi trong quá trình đăng ký",
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

            return BadRequest(new Success<object> { Status = true, Title = "Có lỗi trong quá trình đăng ký", Messages = ["Vui lòng đăng ký lại"] });
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
                return NotFound(new Success<object> { Status = false, Title = "Email hoặc mật khẩu không chính xác.", Messages = ["Vui lòng đăng nhập lại"] });
            }

            var r = await accountRepository.SignInAsync(user, model.Password);
            if (r.IsLockedOut == true)
            {
                return BadRequest(new Success<object> { Status = false, Title = "Tài khoản đã bị khóa", Messages = [$"Đăng nhập sau {user.LockoutEnd}"] });
            }

            if (r.Succeeded == false)
            {
                return BadRequest(new Success<object> { Status = false, Title = "Email hoặc mật khẩu không chính xác.", Messages = ["Incorrect email or password"] });
            }
            string token = await jwtService.CreateJWT(user);

            return Ok(new Success<string> { Status = true, Title = "Đăng nhập thành công", Messages = ["Đăng nhập thành công"], Data = token });
        }

        // phương thức này bấm ở client để gửi đến server
        [HttpPut]
        [Route("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailDto confirm)
        {
            var user = await accountRepository.GetUserByEmailAsync(confirm.Email);
            if (user == null)
            {
                return NotFound(new Success<object> { Status = false, Title = "Không tìm thấy tài khoản", Messages = ["Vui lòng nhập lại email"] });
            }

            if (user.EmailConfirmed == true)
            {
                return BadRequest(new Success<object> { Status = false, Title = "Email đã xác thực", Messages = ["Xin vui lòng đăng nhập"] });
            }

            try
            {
                var decodedTokenBytes = WebEncoders.Base64UrlDecode(confirm.Token);
                var decodedToken = Encoding.UTF8.GetString(decodedTokenBytes);
                var result = await accountRepository.ConfirmEmailAsync(user, decodedToken);

                if (result.Succeeded == true)
                {
                    return Ok(new Success<object> { Status = true, Title = "Xác thực thành công", Messages = ["Đăng nhập ngay bây giờ."] });
                }
                return BadRequest(new Success<object> { Status = false, Title = "Có lỗi", Messages = ["Invalid token. Try again."] });
            }
            catch (Exception)
            {
                return BadRequest(new Success<object> { Status = false, Title = "Có lỗi", Messages = ["Invalid token. Try again."] });
            }
        }

        [HttpGet]
        [Route("resend-confirmation-email/{email}")]
        public async Task<IActionResult> ResendConfirmationEmail(string email)
        {
            if (string.IsNullOrEmpty(email) == true)
            {
                return BadRequest(new Success<object> { Status = false, Title = "Có lỗi", Messages = ["Vui lòng nhập email"] });
            }

            var user = await accountRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound(new Success<object> { Status = false, Title = "Không tìm thấy người dùng", Messages = ["Xin vui lòng nhập lại email."] });
            }

            if (user.EmailConfirmed == true)
            {
                return BadRequest(new Success<object> { Status = false, Title = "Email đã xác thực", Messages = ["Đăng nhập ngay bây giờ."] });
            }

            try
            {
                string token = await accountRepository.GenerateEmailConfirmationTokenAsync(user);
                if (await emailSenderService.SendEmailConfirmAsync(user, token))
                {
                    return Ok(new Success<object> { Status = true, Title = "Đã gửi email", Messages = ["Xin vui lòng kiểm tra email để xác thực"] });
                }
                return BadRequest(new Success<object> { Status = false, Title = "Có lỗi", Messages = ["Xác thực thất bại. Vui lòng thử lại."] });
            }
            catch (Exception)
            {
                return BadRequest(new Success<object> { Status = false, Title = "Xác thực thất bại", Messages = ["Xác thực thất bại. Vui lòng thử lại."] });
            }
        }

        // gửi email reset password đến email
        [HttpGet]
        [Route("send-email-reset-password/{email}")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest(new Success<object> { Status = false, Title = "Có lỗi", Messages = ["Xin vui lòng nhập email"] });
            }

            var user = await accountRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound(new Success<object> { Status = false, Title = "Không tìm thấy tài khoản", Messages = ["Xin vui lòng nhập lại email."] });
            }

            try
            {
                string token = await accountRepository.GeneratePasswordResetTokenAsync(user);
                if (await emailSenderService.SendForgotPasswordEmail(user, token))
                {
                    return Ok(new Success<object> { Status = true, Title = "Đã gửi email", Messages = ["Xin vui lòng kiểm tra email để lấy lại mật khẩu"] });
                }
                return BadRequest(new Success<object> { Status = false, Title = "Có lỗi", Messages = ["Gửi email thất bại. Xin vui lòng thử lại."] });
            }
            catch (Exception)
            {
                return BadRequest(new Success<object> { Status = false, Title = "Có lỗi", Messages = ["Gửi email thất bại. Xin vui lòng thử lại."] });
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
                return NotFound(new Success<object> { Status = false, Title = "Không tìm thấy tài khoản", Messages = ["Vui lòng nhập lại email"] });
            }

            try
            {
                var decodedTokenBytes = WebEncoders.Base64UrlDecode(model.Token);
                var decodedToken = Encoding.UTF8.GetString(decodedTokenBytes);
                var result = await accountRepository.ResetPasswordAsync(user, decodedToken, model.Password);

                if (result.Succeeded == true)
                {
                    return Ok(new Success<object> { Status = true, Title = "Đổi mật khẩu thành công", Messages = ["Mật khẩu của bạn đã được thay đổi. Bạn có thể đăng nhập ngay bây giờ."] });
                }
                return BadRequest(new Success<object> { Status = false, Title = "Có lỗi", Messages = ["Token không hợp lệ."] });
            }
            catch (Exception)
            {
                return BadRequest(new Success<object> { Status = false, Title = "Có lỗi", Messages = ["Token không hợp lệ."] });
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
                return NotFound(new Success<object> { Status = false, Title = "Không tìm thấy tài khoản", Messages = ["Vui lòng nhập lại email."] });
            }
            var r = await accountRepository.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (r.Succeeded == false)
            {
                return BadRequest(new Success<object> { Status = false, Title = "Có lỗi", Messages = r.Errors.Select(e => e.Description).ToList() });
            }

            return Ok(new Success<object> { Status = true, Title = "Thay đổi mật khẩu thành công", Messages = ["Thay đổi mật khẩu thành công."] });
        }
    }
}
