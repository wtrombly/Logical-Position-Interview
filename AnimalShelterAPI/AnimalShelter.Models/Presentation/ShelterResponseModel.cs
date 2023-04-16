using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models.Presentation
{
    public class ShelterResponseModel
    {
        public bool IsAccepted { get; set; }
        public int KennelNumber { get; set; }
        public string AnimalName { get; set; }  
        public string Message { get; set; }
    }
}
