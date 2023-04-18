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
    public class ReorganizeAnimalsService : IReorganizeAnimalsService
    {
        private readonly IShelterKennelRepository _shelterKennelRepository;
        private readonly ISwapAnimalService _swapAnimalService;

        public ReorganizeAnimalsService(IShelterKennelRepository shelterKennelRepository, ISwapAnimalService swapAnimalService)
        {
            _shelterKennelRepository = shelterKennelRepository;
            _swapAnimalService = swapAnimalService; 
        }

        public List<ShelterKennelBO> ReorganizeAnimals()
        {
            var kennels = _shelterKennelRepository.GetShelterKennels();

            int smallAnimalsInLargeKennels = kennels.FindAll(k => k.IsOccupied && k.ShelterAnimal.AnimalSize == Size.Small && k.KennelSize == Size.Large).Count();
            int smallAnimalsInMediumKennels = kennels.FindAll(k => k.IsOccupied && k.ShelterAnimal.AnimalSize == Size.Small && k.KennelSize == Size.Medium).Count();
            int smallAnimalsInSmallKennels = kennels.FindAll(k => k.IsOccupied && k.ShelterAnimal.AnimalSize == Size.Small && k.KennelSize == Size.Small).Count();

            // run the loop to check large kennels with small animals.
            _swapAnimalService.SwapAnimal(kennels, Size.Large, Size.Small, Size.Small);

            // run the loop to check for medium kennels with small animals.
            _swapAnimalService.SwapAnimal(kennels, Size.Medium, Size.Small, Size.Small);

            //run the loop to check for large kennels with medium animals, and swap them into medium kennels
            //no additional check needs to be run for large animals
            _swapAnimalService.SwapAnimal(kennels, Size.Large, Size.Medium, Size.Medium);

            return kennels;
        }
    }
}
