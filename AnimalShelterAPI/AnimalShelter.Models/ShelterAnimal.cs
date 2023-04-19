using AnimalShelter.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class ShelterAnimal : IShelterAnimal
    {
        public string AnimalName { get ; set; }
        public long AnimalId { get; set; }
        public Size AnimalSize { get; set; }
    }
}
