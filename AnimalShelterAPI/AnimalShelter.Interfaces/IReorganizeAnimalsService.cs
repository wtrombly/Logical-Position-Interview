using AnimalShelter.Models.Business;

namespace AnimalShelter.Interfaces
{
    public interface IReorganizeAnimalsService
    {
        public List<ShelterKennelBO> ReorganizeAnimals();
    }
}
