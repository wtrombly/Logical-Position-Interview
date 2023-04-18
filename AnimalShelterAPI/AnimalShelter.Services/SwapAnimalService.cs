using AnimalShelter.Interfaces;
using AnimalShelter.Models.Business;
using AnimalShelter.Models.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class SwapAnimalService : ISwapAnimalService
    {
        private readonly IKennelStateService _kennelStateService;

        public SwapAnimalService(IKennelStateService kennelStateService)
        {
            _kennelStateService = kennelStateService;
        }


        public void SwapAnimal(List<ShelterKennelBO> kennels, Size kennelSizeToCheck, Size animalSizeToCheck, Size kennelSizeToFind)
        {
            foreach (var kennel in kennels) _kennelStateService.SetShelterAnimal(kennel);

            for (int i = 0; i < kennels.Count; i++)
            {
                if (kennels[i].KennelSize == kennelSizeToCheck && kennels[i].IsOccupied == true && kennels[i].ShelterAnimal.AnimalSize == animalSizeToCheck)
                {
                    var smallestVacantKennel = kennels.Find(k => k.IsOccupied == false && k.KennelSize == kennelSizeToFind);

                    Size nextSizeToFind = (Size)(((int)kennelSizeToFind + 1) % Enum.GetValues(typeof(Size)).Length);
                    var nextSmallestVacantKennel = kennels.Find(k => k.IsOccupied == false && k.KennelSize == nextSizeToFind);

                    if (smallestVacantKennel != null)
                    {
                        smallestVacantKennel.ShelterAnimal = kennels[i].ShelterAnimal;
                        smallestVacantKennel.IsOccupied = true;

                        kennels[i].ShelterAnimal = null;
                        kennels[i].IsOccupied = false;
                    }
                    else if (nextSmallestVacantKennel != null)
                    {
                        nextSmallestVacantKennel.ShelterAnimal = kennels[i].ShelterAnimal;
                        nextSmallestVacantKennel.IsOccupied = true;

                        kennels[i].ShelterAnimal = null;
                        kennels[i].IsOccupied = false;
                    }
                }
            }
        }
    }
}
