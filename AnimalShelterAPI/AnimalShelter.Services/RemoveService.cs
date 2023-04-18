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
        private readonly IValidatorService _validatorService;
        public RemoveService(IShelterKennelRepository shelterKennelRepository, IValidatorService validatorService)
        {
            _shelterKennelRepository = shelterKennelRepository;
            _validatorService = validatorService;
        }

        public AdoptionResponseModel RemoveAnimal(AdoptionRequestModel model)
        {

            var response = new AdoptionResponseModel();

            bool animalSheltered = _shelterKennelRepository.IsAnimalSheltered(model);
            if (_validatorService.ValidateAnimalName(model))
            {
                if (animalSheltered)
                {
                    _shelterKennelRepository.RemoveShelteredAnimal(model);
                    response = new AdoptionResponseModel
                    {
                        IsRemoved = true,
                        KennelId = null,
                        AnimalName = model.AnimalName,
                        Message = "The animal has been adopted."
                    };
                }
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
