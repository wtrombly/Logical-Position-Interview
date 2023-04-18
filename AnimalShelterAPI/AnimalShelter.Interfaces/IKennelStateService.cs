using AnimalShelter.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Interfaces
{
    public interface IKennelStateService
    {
        public void SetShelterAnimal(ShelterKennelBO kennel);
    }
}
