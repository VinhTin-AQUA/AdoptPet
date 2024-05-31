using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Data;
using AdoptPet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using AdoptPet.Application.DTOs;


namespace AdoptPet.Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly AdoptPetDbContext _context;

        public PetRepository(AdoptPetDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Pet model)
        {
            await _context.Pets.AddAsync(model);
            await _context.SaveChangesAsync();
            await _context.Entry(model).ReloadAsync();
            return model.Id;
        }

        public Task DeletePermanentlyAsync(Pet model)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedResult<Pet>> GetAllAsync(int pageNumber, int pageSize)
        {
            var petList = await _context.Pets
                        .Select(u => new Pet
                        {
                            Id = u.Id,
                            PetName = u.PetName,
                            PetDescription = u.PetDescription,
                            PetWeight = u.PetWeight,
                            PetAge = u.PetAge,
                            PetGender = u.PetGender,
                            PetDesexed = u.PetDesexed,
                            PetWormed = u.PetWormed,
                            PetVaccined = u.PetVaccined,
                            PetMicrochipped = u.PetMicrochipped,
                            PetEntryDate = u.PetEntryDate,
                            Status = u.Status,
                            IsDeleted = u.IsDeleted,
                            PetImages = u.PetImages.Select(pi => new PetImage
                            {
                                ImgPath = pi.ImgPath,
                            }).ToList()
                        })
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
            var totalItems = await TotalItems();
            return new PaginatedResult<Pet>
            {
                Items = petList,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Pet?> GetByIdAsync(int id)
        {
            Pet? pet = await _context.Pets
                .Select(u => new Pet
                {
                    Id = u.Id,
                    PetName = u.PetName,
                    PetDescription = u.PetDescription,
                    PetWeight = u.PetWeight,
                    PetAge = u.PetAge,
                    PetGender = u.PetGender,
                    PetDesexed = u.PetDesexed,
                    PetWormed = u.PetWormed,
                    PetVaccined = u.PetVaccined,
                    PetMicrochipped = u.PetMicrochipped,
                    PetEntryDate = u.PetEntryDate,
                    Status = u.Status,
                    IsDeleted = u.IsDeleted,
                    PetImages = u.PetImages.Select(pi => new PetImage
                    {
                        ImgPath = pi.ImgPath,
                    }).ToList()
                })
                .Where(p => p.Id == id).FirstOrDefaultAsync();
            return pet;
        }

        public async Task<PaginatedResult<Pet>> SearchPetByCriteria(SearchCriteria searchCriteria, int pageNumber, int pageSize)
        {

            var query = _context.Pets.AsQueryable(); // Start with the Pet table

            // Filter by Name (if provided)
            if (!string.IsNullOrEmpty(searchCriteria.Name))
            {
                query = query.Where(p => p.PetName.Contains(searchCriteria.Name));
            }

            // Filter by Breed (if provided)
            if (searchCriteria.BreedNames != null && searchCriteria.BreedNames.Length > 0)
            {
                query = query.Join(_context.Breeds, p => p.Id, b => b.Id, (p, pb) => new { Pet = p, Breed = pb })
                             .Where(x => searchCriteria.BreedNames.Contains(x.Breed.BreedName))
                             .Select(x => x.Pet);
            }

            // Filter by Color (if provided)
            if (searchCriteria.ColourNames != null && searchCriteria.ColourNames.Length > 0)
            {
                query = query.Join(_context.Colours, p => p.Id, c => c.Id, (p, c) => new { Pet = p, Colour = c })
                             .Where(x => searchCriteria.ColourNames.Contains(x.Colour.ColourName))
                             .Select(x => x.Pet);
            }

            // Filter by Sex (if provided)
            if (searchCriteria.Gender.HasValue)
            {
                query = query.Where(p => p.PetGender == searchCriteria.Gender.Value);
            }

            // Filter by Desexed (if provided)
            if (searchCriteria.Desexed.HasValue)
            {
                query = query.Where(p => p.PetDesexed == (searchCriteria.Desexed.Value ? 1 : 0));
            }

            if (searchCriteria.AgeRange != null)
            {
                query = query.Where(p => p.PetAge == searchCriteria.AgeRange);
            }
            //Take the total count before applying pagination
            var totalItems = await query.CountAsync();
            // Apply pagination
            var paginatedQuery = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedResult<Pet>
            {
                Items = paginatedQuery,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

        }

        public async Task<PaginatedResult<Pet>> SearchPetsByBreedAsync(int breedId, int pageNumber, int pageSize)
        {
            var listPets = from pet in _context.Pets
                           join Breed in _context.Breeds
                           on pet.breed.Id equals Breed.Id
                           where Breed.Id == breedId
                           && pet.IsDeleted == false // Assuming you have a flag for soft deletes
                           select pet;
            var totalItems = await listPets.CountAsync();
            var paginatedQuery = await listPets.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedResult<Pet>
            {
                Items = paginatedQuery,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public Task<int> SoftDelete(Pet pet)
        {
            pet.IsDeleted = !pet.IsDeleted;
            _context.Pets.Update(pet);
            return _context.SaveChangesAsync();
        }

        public Task<int> TotalItems()
        {
            return _context.Pets.CountAsync();
        }

        public Task<int> UpdateAsync(Pet model)
        {
            _context.Pets.Update(model);
            return _context.SaveChangesAsync();
        }
       
    }
}