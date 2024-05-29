using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptPet.Application.DTOs
{
    public class PetImageDTO
    {
        public int Id { get; set; }
        public string ImgPath { get; set; } = string.Empty;
        public int PetId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
