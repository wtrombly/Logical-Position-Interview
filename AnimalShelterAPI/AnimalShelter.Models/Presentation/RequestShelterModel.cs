using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models.Presentation
{
    public class RequestShelterModel
    {
        public string AnimalType { get; set; }
        public string AnimalName { get; set; }
        public double AnimalSizeInLbs { get; set; }
    }
}
