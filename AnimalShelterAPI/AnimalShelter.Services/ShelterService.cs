using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalShelter.Interfaces;
using AnimalShelter.Models.Business;
using AnimalShelter.Models.Presentation;

namespace AnimalShelter.Services
{
    public class ShelterService : IShelterService
    {
        private readonly IKennelCapacityService _kennelCapacityService;
        private readonly IShelterKennelRepository _shelterKennelRepository;
        private readonly IValidatorService _validatorService;
        private const int c_smallSizeLimit = 20;
        private const int c_mediumSizeLimit = 50;

        public ShelterService(IKennelCapacityService kennelCapacityService, IShelterKennelRepository shelterKennelRepository, IValidatorService validatorService)
        {
            _kennelCapacityService = kennelCapacityService;
            _shelterKennelRepository = shelterKennelRepository;
            _validatorService = validatorService;
        }

        public ShelterResponseModel ShelterAnimal(ShelterRequestModel model)
        {

            // if there are zero vacant, refuse animal
            //  validation check before making a database pull
            if(!_validatorService.ValidateShelterRequestModel(model))
            {
                return new ShelterResponseModel
                {
                    IsAccepted = false,
                    AnimalName = model.AnimalName,
                    Message = "Animal size must be greater than 0 lbs."
                };
            }

            var kennels = _shelterKennelRepository.GetShelterKennels();
            
            var kennelCapacity = _kennelCapacityService.CalculateKennelCapacity(kennels);

            // if a small animal, check for the best kennel first and get smaller, assign accordingly
            //// this is a lot of checks that could be broken out into separate services and have better unit testing.
            // a separate service has not been implemented as the defintion of "best" kennel is not defined in the prompt.
            if (model.AnimalSizeInLbs <= c_smallSizeLimit && kennelCapacity.LargeKennelCountVacant > 0)
            {
                int assignedKennel = kennelCapacity.LargeVacantKennelIds[0];

                var response = new ShelterResponseModel
                {
                    IsAccepted = true,
                    KennelId = assignedKennel,
                    AnimalName = model.AnimalName,
                    Message = "Please proceed with sheltering the animal in kennel number:" + assignedKennel
                };
                _shelterKennelRepository.UpdateShelterKennel(response);
                return response;
            }
            else if (model.AnimalSizeInLbs <= c_smallSizeLimit && kennelCapacity.MediumKennelCountVacant > 0)
            {
                int assignedKennel = kennelCapacity.MediumVacantKennelIds[0];

                var response = new ShelterResponseModel
                {
                    IsAccepted = true,
                    KennelId = assignedKennel,
                    AnimalName = model.AnimalName,
                    Message = "Please proceed with sheltering the animal in kennel number:" + assignedKennel
                };
                _shelterKennelRepository.UpdateShelterKennel(response);
                return response;
            }
            else if (model.AnimalSizeInLbs <= c_smallSizeLimit && kennelCapacity.SmallKennelCountVacant > 0)
            {
                int assignedKennel = kennelCapacity.SmallVacantKennelIds[0];

                var response = new ShelterResponseModel
                {
                    IsAccepted = true,
                    KennelId = assignedKennel,
                    AnimalName = model.AnimalName,
                    Message = "Please proceed with sheltering the animal in kennel number:" + assignedKennel
                };

                _shelterKennelRepository.UpdateShelterKennel(response);
                return response;
            }

            // if a medium sized animal, check for the best kennel first and get smaller, assign accordingly
            if (model.AnimalSizeInLbs >= c_smallSizeLimit && model.AnimalSizeInLbs <= c_mediumSizeLimit && kennelCapacity.LargeKennelCount > 0)
            {
                int assignedKennel = kennelCapacity.LargeVacantKennelIds[0];
                var response = new ShelterResponseModel
                {
                    IsAccepted = true,
                    KennelId = assignedKennel,
                    AnimalName = model.AnimalName,
                    Message = "Please proceed with sheltering the animal in kennel number:" + assignedKennel
                };

                _shelterKennelRepository.UpdateShelterKennel(response);
                return response;
            }
            else if (model.AnimalSizeInLbs >= c_smallSizeLimit && model.AnimalSizeInLbs <= c_mediumSizeLimit && kennelCapacity.LargeKennelCount > 0)
            {
                int assignedKennel = kennelCapacity.MediumVacantKennelIds[0];
                var response = new ShelterResponseModel
                {
                    IsAccepted = true,
                    KennelId = assignedKennel,
                    AnimalName = model.AnimalName,
                    Message = "Please proceed with sheltering the animal in kennel number:" + assignedKennel
                };

                _shelterKennelRepository.UpdateShelterKennel(response);
                return response;
            }
            // if large animal, check that there is a large vacant kennel
            if (model.AnimalSizeInLbs >= c_mediumSizeLimit && kennelCapacity.LargeKennelCount > 0)
            {
                int assignedKennel = kennelCapacity.LargeVacantKennelIds[0];
                var response = new ShelterResponseModel
                {
                    IsAccepted = true,
                    KennelId = assignedKennel,
                    AnimalName = model.AnimalName,
                    Message = "Please proceed with sheltering the animal in kennel number:" + assignedKennel
                };

                _shelterKennelRepository.UpdateShelterKennel(response);
                return response;
            }

            return new ShelterResponseModel
            {
                IsAccepted = false,
                Message = "Unable to shelter animal due to lack of vacancy."
            };
        }
    }
}
