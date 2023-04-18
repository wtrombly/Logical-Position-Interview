using AnimalShelter.Models.Business;
using AnimalShelter.Models.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Interfaces
{
    public interface ISwapAnimalService
    {
        public void SwapAnimal(List<ShelterKennelBO> kennels, Size kennelSizeToCheck, Size animalSizeToCheck, Size kennelSizeToFind);
    }
}
