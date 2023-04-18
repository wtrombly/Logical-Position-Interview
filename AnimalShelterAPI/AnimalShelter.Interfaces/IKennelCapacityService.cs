using AnimalShelter.Models.Business;
using AnimalShelter.Models.Presentation;

namespace AnimalShelter.Interfaces
{
    public interface IKennelCapacityService
    {
        KennelCapacityBO CalculateKennelCapacity(List<ShelterKennelBO> kennels);
    }
}
