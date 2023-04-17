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
    public class ReorganizeAnimalsService
    {
        private readonly IShelterKennelRepository _shelterKennelRepository;
        private readonly KennelCapacityService _kennelCapacityService;

        public ReorganizeAnimalsService(IShelterKennelRepository shelterKennelRepository)
        {
            _shelterKennelRepository = shelterKennelRepository;

            var kennels = _shelterKennelRepository.GetShelterKennels();

            int smallAnimalsInLargeKennels = kennels.FindAll(k => k.IsOccupied && k.ShelterAnimal.AnimalSize == Size.Small && k.KennelSize == Size.Large).Count();
            int smallAnimalsInMediumKennels = kennels.FindAll(k => k.IsOccupied && k.ShelterAnimal.AnimalSize == Size.Small && k.KennelSize == Size.Medium).Count();
            int smallAnimalsInSmallKennels = kennels.FindAll(k => k.IsOccupied && k.ShelterAnimal.AnimalSize == Size.Small && k.KennelSize == Size.Small).Count();

            // run the loop to check large kennels with small animals.
            SwapAnimal(kennels, Size.Large, Size.Small, Size.Small);

            // run the loop to check for medium kennels with small animals.
            SwapAnimal(kennels, Size.Medium, Size.Small, Size.Small);

            //run the loop to check for large kennels with medium animals, and swap them into medium kennels
            //no additional check needs to be run for large animals
            SwapAnimal(kennels, Size.Large, Size.Medium, Size.Medium);

        }

        // could be optimized to iterate through only the list that has kennels that need to be checked.
        // in the event that this size of kennels becomes larger, this can be modified.
        public void SwapAnimal(List<ShelterKennelBO> kennels, Size kennelSizeToCheck, Size animalSizeToCheck, Size kennelSizeToFind)
        {

            for (int i = 0; i < kennels.Count; i++)
            {
                if (kennels[i].KennelSize == kennelSizeToCheck && kennels[i].ShelterAnimal.AnimalSize == animalSizeToCheck)
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
