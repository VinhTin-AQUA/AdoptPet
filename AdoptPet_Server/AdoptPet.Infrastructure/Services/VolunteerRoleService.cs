using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;

public class VolunteerRoleService
{
    private readonly IVolunteerRoleRepository _repository;

    public VolunteerRoleService(IVolunteerRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<VolunteerRole> GetVolunteerRoleByIdAsync(int id)
    {
        // Implement logic to get volunteer role by id from the repository
        VolunteerRole? role = await _repository.GetByIdAsync(id);
        if(role == null)
        {
            throw new InvalidOperationException($"VolunteerRole with id {id} not found.");
        }
        return role;
    }

    public async Task<PaginatedResult<VolunteerRole>> GetAllVolunteerRolesAsync(int pageNumber, int pageSize)
    {
        return await _repository.GetAllAsync(pageNumber,pageSize);
    }

    public async Task<int> AddVolunteerRoleAsync(VolunteerRole role)
    {
        if (role == null)
        {
            throw new ArgumentNullException(nameof(role));
        }

        return await _repository.AddAsync(role);
    }

    public async Task<bool> UpdateVolunteerRoleAsync(VolunteerRole role)
    {
        if (role == null)
        {
            throw new ArgumentNullException(nameof(role));
        }

        var existingRole = await _repository.GetByIdAsync(role.Id);
        if (existingRole == null)
        {
            throw new InvalidOperationException($"VolunteerRole with id {role.Id} not found.");
        }
        await _repository.UpdateAsync(role);
        return true;
    }

    public async Task<bool> DeleteVolunteerRoleAsync(int id)
    {
        var existingRole = await _repository.GetByIdAsync(id);
        if (existingRole == null)
        {
            throw new InvalidOperationException($"VolunteerRole with id {id} not found.");
        }

        await _repository.DeletePermanentlyAsync(existingRole);
        return true;
    }

    public async Task<bool> SoftDeleteVolunteerRoleAsync(int id)
    {
        var existingRole = await _repository.GetByIdAsync(id);
        if (existingRole == null)
        {
            throw new InvalidOperationException($"VolunteerRole with id {id} not found.");
        }

        await _repository.SoftDelete(id);
        return true;
    }
}
