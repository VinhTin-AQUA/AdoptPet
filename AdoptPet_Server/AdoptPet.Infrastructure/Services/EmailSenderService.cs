using AdoptPet.Application.DTOs.Email;
using AdoptPet.Application.Interfaces;
using AdoptPet.Domain.Entities;
using AdoptPet.Domain.Settings;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Text;

namespace AdoptPet.Infrastructure.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        // inject dịch vụ EmailConfiguration để lấy cấu hình gửi mail
        private readonly EmailConfiguration emailConfig;
        private readonly IConfiguration configuration;

        public EmailSenderService(EmailConfiguration emailConfig, IConfiguration configuration)
        {
            this.emailConfig = emailConfig;
            this.configuration = configuration;
        }

        // tạo email (thư gửi đi)
        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(emailConfig.DisplayName, emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            /* gửi với nội dung có thể ở định dạng HTML */
            //var bodyBuilder = new BodyBuilder();
            //bodyBuilder.HtmlBody = message.Content;
            //emailMessage.Body = bodyBuilder.ToMessageBody();
            // hoặc
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content };

            /* gửi với nội dung văn bản thuần túy */
            //emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }

        private async Task<bool> SendEmail(Message email)
        {
            bool isSent = true;
            // tạo email
            var emailMessage = CreateEmailMessage(email);
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(emailConfig.SmtpServer, emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(emailConfig.UserName, emailConfig.Password);
                    await client.SendAsync(emailMessage);
                }
                catch
                {
                    isSent = false;
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
            return isSent;
        }

        public async Task<bool> SendEmailConfirmAsync(AppUser user, string token)
        {
            token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var url = $"{configuration["JWT:UrlClient"]}/" +
                $"{configuration["EmailConfiguration:ConfirmationEmailPath"]}" +
                $"?token={token}&email={user.Email}";

            Message message = new([user.Email!],
                "Confirm Email",
                $"<p>We really happy when you using my app. Click <a href='{url}'>here</a> to verify email</p>"!);
            return await SendEmail(message);
        }

        public async Task<bool> SendForgotPasswordEmail(AppUser user, string token)
        {
            token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var url = $"{configuration["JWT:UrlClient"]}/" +
                $"{configuration["EmailConfiguration:ResetPasswordPath"]}" +
                $"?token={token}&email={user.Email}";

            Message message = new Message(new string[] { user.Email! },
                "Reset password",
                $"<p>To reset your password, please click <a href='{url}'>here</a></p>"!);
            return await SendEmail(message);
        }
    }
}
