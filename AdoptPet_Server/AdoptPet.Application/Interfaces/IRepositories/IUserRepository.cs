﻿using AdoptPet.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdoptPet.Application.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<List<AppUser>> GetAllUsers(int pageNumber, int pageSize);
        Task<List<AppUser>> SearchUserByName(string name);
        Task<IdentityResult> LockUser(AppUser user);
        Task<IdentityResult> UnLockUser(AppUser user);
        Task AddUser();
        Task RemoveUser(AppUser user);
    }
}
