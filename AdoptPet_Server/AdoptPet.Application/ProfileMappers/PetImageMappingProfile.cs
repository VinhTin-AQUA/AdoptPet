using AdoptPet.Application.DTOs;
using AdoptPet.Domain.Entities;
using AutoMapper;

namespace AdoptPet.Application.Profiles
{
    public class PetImageMappingProfile : Profile
    {
        public PetImageMappingProfile()
        {
            CreateMap<PetImage, PetImageDTO>()
                .ReverseMap();
        }
    }
}
