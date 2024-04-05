using AdoptPet.Domain.Entities;

namespace AdoptPet.Application.Interfaces
{
    public interface IEmailSenderService
    {
        Task<bool> SendEmailConfirmAsync(AppUser user, string token);
        Task<bool> SendForgotPasswordEmail(AppUser user, string token);
    }
}
