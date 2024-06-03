using AdoptPet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptPet.Application.DTOs
{
    public class ListPetImage
    {
        public List<PetImageDTO> NormalImages { get; set; } = new List<PetImageDTO>();
        public List<PetImageDTO> PanoramaImages { get; set; } = new List<PetImageDTO>();
        public List<PetImageDTO> Rotated360Images { get; set; } = new List<PetImageDTO>();
    }
}
