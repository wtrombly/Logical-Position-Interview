using AnimalShelter.Models.Presentation;

namespace AnimalShelter.Interfaces
{
    public interface IRemoveService
    {
        AdoptionResponseModel RemoveAnimal(AdoptionRequestModel model);
    }
}
