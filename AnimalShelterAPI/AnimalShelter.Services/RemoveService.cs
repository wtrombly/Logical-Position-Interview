using AnimalShelter.Interfaces;
using AnimalShelter.Models.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class RemoveService : IRemoveService
    {
        private readonly IShelterKennelRepository _shelterKennelRepository;
        public RemoveService(IShelterKennelRepository shelterKennelRepository)
        {
            _shelterKennelRepository = shelterKennelRepository;
        }
        //// we should use a validator service to check for required values.
        //// I havent removed the animal here, that is an issue!
        //// we can just remove the animal, and then provide some identifier to remove. create function in ShelterKennelRepository for boolean response.
        public AdoptionResponseModel RemoveAnimal(AdoptionRequestModel model)
        {
            //remove the following 2 lines
          //  var kennels = _shelterKennelRepository.GetShelterKennels();
          //  d = kennels.Find(k => k.ShelterAnimal.AnimalName == model.AnimalName) != null;
            // add call to repo method to remove animal by name
            var response = new AdoptionResponseModel();

            bool animalSheltered = _shelterKennelRepository.IsAnimalSheltered(model);

            if (animalSheltered)
            {
                response = new AdoptionResponseModel
                {
                    IsRemoved = true,
                    KennelId = null,
                    AnimalName = model.AnimalName,
                    Message = "The animal has been adopted."
                };
            }

            response = new AdoptionResponseModel
            {
                IsRemoved = false,
                KennelId = null,
                AnimalName = model.AnimalName,
                Message = "Unable to find animal with animal name:" + model.AnimalName
            };

            return response;
        }
    }
}
