using AnimalShelter.Models.Business;

namespace AnimalShelter.Interfaces
{
    public interface IKennelCapacityService
    {
        KennelCapacityBO CalculateKennelCapacity(List<ShelterKennelBO> kennels);
    }
}
