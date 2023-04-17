using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AnimalShelter.Models.Business
{
    public class ShelterKennelBO 
    {
        public int KennelIdValue { get; set; } 
        public Size KennelSize { get; set; }
        public bool IsOccupied { get; set; }
        public IShelterAnimal ShelterAnimal { get; set; }
    }

    public enum Size
    {
        Small,
        Medium,
        Large
    }
}
