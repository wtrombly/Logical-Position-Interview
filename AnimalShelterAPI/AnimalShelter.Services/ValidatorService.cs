using AnimalShelter.Interfaces;
using AnimalShelter.Models.Presentation;


namespace AnimalShelter.Services
{
    public class ValidatorService : IValidatorService
    {
        public bool ValidateShelterRequestModel(ShelterRequestModel model)
        {
            return model.AnimalSizeInLbs > 0;
        }
    }
}
