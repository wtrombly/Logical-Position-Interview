using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models.Presentation
{
    public  class RequestShelterModel
    {
        string AnimalType { get; set; }
        string AnimalName { get; set; }
        double AnimalSizeInLbs { get; set; }
    }
}
