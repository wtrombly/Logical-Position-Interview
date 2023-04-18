using AnimalShelter.Interfaces;
using AnimalShelter.Models.Business;
using AnimalShelter.Models.Presentation;

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

        // could optimize to check only occupied kennels
        public List<ShelterKennelBO> ReorganizeAnimals()
        {
            var kennels = _shelterKennelRepository.GetShelterKennels();

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
