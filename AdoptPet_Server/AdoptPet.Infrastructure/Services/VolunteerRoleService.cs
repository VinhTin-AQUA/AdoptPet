using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;

public class VolunteerRoleService : IGenericService<VolunteerRole>
{
    private readonly IVolunteerRoleRepository _repository;

    public VolunteerRoleService(IVolunteerRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<VolunteerRole?> GetByIdAsync(int id)
    {
        // Implement logic to get volunteer role by id from the repository
        VolunteerRole? role = await _repository.GetByIdAsync(id);
        if(role == null)
        {
            throw new InvalidOperationException($"VolunteerRole with id {id} not found.");
        }
        return role;
    }

    public async Task<PaginatedResult<VolunteerRole>> GetAllAsync(int pageNumber, int pageSize)
    {
        int totalItems = await _repository.TotalItems();
        string validationMessage = await IGenericService<VolunteerRole>.ValidateNumber(totalItems, pageNumber, pageSize);
        if (String.IsNullOrEmpty(validationMessage))
        {
            throw new Exception(validationMessage);
        }
        var listVolunteerRole = await _repository.GetAllAsync(pageNumber,pageSize);
        if (listVolunteerRole.Items == null)
        {
            throw new Exception("List of VolunteerRoles is empty");
        }
        return listVolunteerRole;
    }

    public async Task<int?> AddAsync(VolunteerRole role)
    {
        if (role == null)
        {
            throw new ArgumentNullException(nameof(role));
        }

        int affectedRows = await _repository.AddAsync(role);
        if (affectedRows == 0)
        {
            throw new Exception("Failed to add VolunteerRole");
        }
        return affectedRows;
    }

    public async Task<int?> UpdateAsync(int Id, VolunteerRole role)
    {
        if (role == null)
        {
            throw new Exception(nameof(role));
        }

        var existingRole = await _repository.GetByIdAsync(Id);
        if (existingRole == null)
        {
            throw new Exception($"VolunteerRole with id {Id} not found.");
        }
        existingRole.Description = role.Description;
        existingRole.Name = role.Name;

        int affectedRows = await _repository.UpdateAsync(existingRole);
        if(affectedRows == 0)
        {
            throw new Exception($"Failed to update VolunteerRole with id {role.Id}");
        }
        return affectedRows;
    }

    //public async Task<int> DeletePermanentlyAsync(int id)
    //{
    //    var existingRole = await _repository.GetByIdAsync(id);
    //    if (existingRole == null)
    //    {
    //        throw new InvalidOperationException($"VolunteerRole with id {id} not found.");
    //    }

    //    int affectedRows = await _repository.DeletePermanentlyAsync(existingRole);
    //    if (affectedRows == 0)
    //    {
    //        throw new Exception($"Failed to delete VolunteerRole with id {id}");
    //    }
    //    return affectedRows;
    //}

    public async Task<int> SoftDelete(int id)
    {
        var existingRole = await _repository.GetByIdAsync(id);
        if (existingRole == null)
        {
            throw new InvalidOperationException($"VolunteerRole with id {id} not found.");
        }

        int affectedRows = await _repository.SoftDelete(existingRole);
        if (affectedRows == 0)
        {
            throw new Exception($"Failed to soft delete VolunteerRole with id {id}");
        }
        return affectedRows;
    }
}
