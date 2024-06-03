using AdoptPet.Application.DTOs;
using AdoptPet.Application.Interfaces.IRepositories;
using AdoptPet.Application.Interfaces.IService;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;
using AutoMapper;

namespace AdoptPet.Application.Services
{
    public class PetImageService : IPetImageService
    {
        private readonly IPetImageRepository _petImageRepository;
        private readonly IMapper _mapper;

        public PetImageService(IPetImageRepository petImageRepository, IMapper mapper)
        {
            _petImageRepository = petImageRepository;
            _mapper = mapper;
        }

        public async Task<int?> AddAsync(PetImageDTO petImageDto)
        {
            if (petImageDto == null)
            {
                throw new InvalidDataException("PetImageDto cannot be null.");
            }

            var petImage = _mapper.Map<PetImage>(petImageDto);
            var generatedId = await _petImageRepository.AddAsync(petImage);
            if (generatedId == 0)
            {
                throw new InvalidOperationException("Failed to add PetImage.");
            }
            return generatedId;
        }

        public async Task<int> AddManyImagesAsync(List<PetImageDTO> petImageDtos)
        {
            if (petImageDtos == null || petImageDtos.Count == 0)
            {
                throw new InvalidDataException("PetImageDtos cannot be null or empty.");
            }

            var petImages = _mapper.Map<List<PetImage>>(petImageDtos);
            var affectedRows = await _petImageRepository.AddManyImagesAsync(petImages);
            if(affectedRows == 0)
            {
                throw new InvalidOperationException("Failed to add PetImages.");
            }
            return affectedRows;
        }

        public async Task DeletePermanentlyAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("ID must be greater than zero.");
            }
            var petImage = await _petImageRepository.GetByIdAsync(id);
            if (petImage == null)
            {
                throw new ArgumentNullException($"No PetImage found with ID {id}.");
            }

            await _petImageRepository.DeletePermanentlyAsync(petImage);
        }

        public async Task<PaginatedResult<PetImageDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            int totalItems = await _petImageRepository.TotalItems();
            String validationMessage = await IPetService.ValidateNumber(totalItems, pageNumber, pageSize);
            if (!String.IsNullOrEmpty(validationMessage))
            {
                throw new InvalidDataException(validationMessage);
            }

            var images = await _petImageRepository.GetAllAsync(pageNumber, pageSize);
            if(images.Items == null || images.Items.Count == 0)
            {
                throw new InvalidOperationException("No PetImages found.");
            }
            var imageDtos = _mapper.Map<List<PetImageDTO>>(images.Items);

            return new PaginatedResult<PetImageDTO>
            {
                Items = imageDtos,
                TotalItems = images.TotalItems,
                PageNumber = images.PageNumber,
                PageSize = images.PageSize
            };
        }

        public async Task<ListPetImage> GetAllPetImageByPetId(int petId)
        {
            if (petId <= 0)
            {
                throw new InvalidDataException("PetId must be greater than zero.");
            }

            var images = await _petImageRepository.GetAllPetImageByPetId(petId);
            if (images == null || images.Count == 0)
            {
                throw new InvalidOperationException($"No PetImages found for Pet with ID {petId}.");
            }
            var imageDtos = _mapper.Map<List<PetImageDTO>>(images);
            
            return new ListPetImage
            {
                NormalImages = (List<PetImageDTO>)imageDtos.Where(i => i.ImageType == ImageType.Normal),
                PanoramaImages = (List<PetImageDTO>)imageDtos.Where(i => i.ImageType == ImageType.Panorama),
                Rotated360Images = (List<PetImageDTO>)imageDtos.Where(i => i.ImageType == ImageType.Rotated360)
            };
        }

        public async Task<PetImageDTO?> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("ID must be greater than zero.");
            }

            var petImage = await _petImageRepository.GetByIdAsync(id);
            if (petImage == null)
            {
                throw new InvalidOperationException($"No PetImage found with ID {id}.");
            }

            return _mapper.Map<PetImageDTO>(petImage);
        }

        public async Task<int> SoftDelete(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("ID must be greater than zero.");
            }

            var petImage = await _petImageRepository.GetByIdAsync(id);
            if (petImage == null)
            {
                throw new InvalidOperationException($"No PetImage found with ID {id}.");
            }
            var affectedRows = await _petImageRepository.SoftDelete(petImage);
            if (affectedRows == 0)
            {
                throw new InvalidOperationException("Failed to soft delete PetImage.");
            }
            return affectedRows;
        }

        public async Task<int?> UpdateAsync(int Id, PetImageDTO petImageDto)
        {
            if (petImageDto == null)
            {
                throw new InvalidDataException("PetImageDto cannot be null.");
            }

            var petImage = await _petImageRepository.GetByIdAsync(petImageDto.Id);
            if (petImage == null)
            {
                throw new ArgumentNullException($"No PetImage found with ID {petImageDto.Id}.");
            }

            _mapper.Map(petImageDto, petImage);
            var affectedRows = await _petImageRepository.UpdateAsync(petImage);
            if (affectedRows == 0)
            {
                throw new InvalidOperationException("Failed to update PetImage.");
            }
            return affectedRows;
        }

        public async Task<int> UpdateManyImagesAsync(List<PetImageDTO> petImageDtos)
        {
            if (petImageDtos == null || petImageDtos.Count == 0)
            {
                throw new ArgumentNullException("PetImageDtos cannot be null or empty.");
            }

            var petImages = _mapper.Map<List<PetImage>>(petImageDtos);
            var affectedRows = await _petImageRepository.UpdateManyImagesAsync(petImages);
            if (affectedRows == 0)
            {
                throw new InvalidOperationException("Failed to update PetImages.");
            }
            return affectedRows;
        }
    }
}
