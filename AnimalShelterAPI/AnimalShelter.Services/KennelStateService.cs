using AnimalShelter.Interfaces;
using AnimalShelter.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public  class KennelStateService : IKennelStateService
    {
        public void SetShelterAnimal(ShelterKennelBO kennel)
        {
            kennel.IsOccupied = kennel.ShelterAnimal != null;
        }
    }
}
