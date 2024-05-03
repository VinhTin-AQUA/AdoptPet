using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptPet.Application.DTOs
{
    public class SearchCriteria
    {
        public string Name { get; set; }
        public int[] BreedIds { get; set; }
        public int[] ColourIds { get; set; }
        public byte? Sex { get; set; }
        public bool? Desexed { get; set; }
        public string AgeRange { get; set; }
    }
}
