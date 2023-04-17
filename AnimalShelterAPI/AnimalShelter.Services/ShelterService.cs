using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalShelter.Interfaces;
using AnimalShelter.Models.Presentation;

namespace AnimalShelter.Services
{
    public class ShelterService : IShelterService
    {

        private readonly KennelCapacityService _kennelCapacityService;
        private readonly IShelterKennelRepository _shelterKennelRepository;

        public ShelterService(KennelCapacityService kennelCapacityService, IShelterKennelRepository shelterKennelRepository)
        {
            _kennelCapacityService = kennelCapacityService;
            _shelterKennelRepository = shelterKennelRepository;
        }

        public ResponseShelterModel ShelterAnimal(RequestShelterModel model)
        {

            int smallSizeLimit = 20;
            int mediumSizeLimit = 50;
            var kennelCapacity = _kennelCapacityService.KennelCapacity;
            // if no kennels are vacant, refuse animal
            if (model.AnimalSizeInLbs == 0)
            {
                return new ResponseShelterModel
                {
                    IsAccepted = false,
                    AnimalName = model.AnimalName,
                    Message = "Animal size must be greater than 0 lbs."
                };
            }


            // if a small animal, check for the best kennel first and get smaller, assign accordingly
            if (model.AnimalSizeInLbs <= smallSizeLimit && kennelCapacity.LargeKennelCountVacant > 0)
            {
                int assignedKennel = kennelCapacity.LargeVacantKennelIds[0];

                var response = new ResponseShelterModel
                {
                    IsAccepted = true,
                    KennelId = assignedKennel,
                    AnimalName = model.AnimalName,
                    Message = "Please proceed with sheltering the animal in kennel number:" + assignedKennel
                };
                _shelterKennelRepository.UpdateShelterKennel(response);
                return response;
            }
            else if (model.AnimalSizeInLbs <= smallSizeLimit && kennelCapacity.MediumKennelCountVacant > 0)
            {
                int assignedKennel = kennelCapacity.MediumVacantKennelIds[0];

                var response = new ResponseShelterModel
                {
                    IsAccepted = true,
                    KennelId = assignedKennel,
                    AnimalName = model.AnimalName,
                    Message = "Please proceed with sheltering the animal in kennel number:" + assignedKennel
                };
                _shelterKennelRepository.UpdateShelterKennel(response);
                return response;
            }
            else if (model.AnimalSizeInLbs <= smallSizeLimit && kennelCapacity.SmallKennelCountVacant > 0)
            {
                int assignedKennel = kennelCapacity.SmallVacantKennelIds[0];

                var response = new ResponseShelterModel
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
            if (model.AnimalSizeInLbs >= smallSizeLimit && model.AnimalSizeInLbs <= mediumSizeLimit && kennelCapacity.LargeKennelCount > 0)
            {
                int assignedKennel = kennelCapacity.LargeVacantKennelIds[0];
                var response = new ResponseShelterModel
                {
                    IsAccepted = true,
                    KennelId = assignedKennel,
                    AnimalName = model.AnimalName,
                    Message = "Please proceed with sheltering the animal in kennel number:" + assignedKennel
                };
                _shelterKennelRepository.UpdateShelterKennel(response);
                return response;
            }
            else if(model.AnimalSizeInLbs >= smallSizeLimit && model.AnimalSizeInLbs <= mediumSizeLimit && kennelCapacity.LargeKennelCount > 0)
            {
                int assignedKennel = kennelCapacity.MediumVacantKennelIds[0];
                var response = new ResponseShelterModel
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
            if (model.AnimalSizeInLbs >= mediumSizeLimit && kennelCapacity.LargeKennelCount > 0)
            {
                int assignedKennel = kennelCapacity.LargeVacantKennelIds[0];
                var response = new ResponseShelterModel
                {
                    IsAccepted = true,
                    KennelId = assignedKennel,
                    AnimalName = model.AnimalName,
                    Message = "Please proceed with sheltering the animal in kennel number:" + assignedKennel
                };
                _shelterKennelRepository.UpdateShelterKennel(response);
                return response;
            }

            return new ResponseShelterModel
            {
                IsAccepted = false,
                Message = "Unable to shelter animal due to lack of vacancy."
            };

        }

        


    }
}
