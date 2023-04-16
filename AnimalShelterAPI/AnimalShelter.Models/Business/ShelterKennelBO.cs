using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models.Business
{
    public interface ShelterKennelBO
    {
        public int KennelIDValue { get; set; } 
        KennelSize KennelSize { get; set; }
        public bool IsOccupied { get; set; }
    }
}
