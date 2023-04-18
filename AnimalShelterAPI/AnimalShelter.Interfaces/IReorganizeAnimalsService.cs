using AnimalShelter.Models.Business;
using AnimalShelter.Models.Presentation;

namespace AnimalShelter.Interfaces
{
    public interface IReorganizeAnimalsService
    {
        public List<ShelterKennelBO> ReorganizeAnimals();
    }
}
