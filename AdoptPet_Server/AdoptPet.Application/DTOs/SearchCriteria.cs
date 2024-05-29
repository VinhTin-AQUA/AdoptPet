using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptPet.Application.DTOs
{
    public class SearchCriteria
    {

        public string? Name { get; set; }
        public String[]? BreedNames { get; set; } //
        public String[]? ColourNames { get; set; }
        public byte? Gender { get; set; }
        public bool? Desexed { get; set; }
        public string? AgeRange { get; set; }

    }
}
