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
        // could create additional presentation model that contains kennels, as well as message for status of kennels (for example, being length zero, and also summary statistics of kennels(new service))
        public List<ShelterKennelBO> ReorganizeAnimals()
        {
            var kennels = _shelterKennelRepository.GetShelterKennels();
            
            // Optimizaion: no sense attempting loops and calling another function when kennels is null
            if (kennels == null) { return kennels; }

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
