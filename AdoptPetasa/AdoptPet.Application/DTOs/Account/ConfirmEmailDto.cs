﻿

namespace AdoptPet.Application.DTOs.Account
{
    public class ConfirmEmailDto
    {
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
