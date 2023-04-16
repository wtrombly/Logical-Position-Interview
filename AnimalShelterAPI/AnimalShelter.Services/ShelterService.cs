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

        public ShelterResponseModel ShelterAnimal(RequestShelterModel model)
        {

            int smallSizeLimit = 20;
            int mediumSizeLimit = 50;
            var kennelCapacity = _kennelCapacityService.KennelCapacity;

            if (model.AnimalSizeInLbs == 0)
            {
                return new ShelterResponseModel
                {
                    IsAccepted = false,
                    KennelNumber = 0,
                    AnimalName = model.AnimalName,
                    Message = "Animal size must be greater than 0 lbs. Are we providing shelter for an animal?"
                };
            }

            if (model.AnimalSizeInLbs <= smallSizeLimit && kennelCapacity.SmallKennelCountVacant > 0)
            {
                int assignedKennel = kennelCapacity.SmallVacantKennelIds[0];
                                
                var response = new ShelterResponseModel
                {
                    IsAccepted = true,
                    KennelNumber = assignedKennel,
                    AnimalName = model.AnimalName,
                    Message = "Please proceed with sheltering the animal in kennel number:" + assignedKennel
                };
                _shelterKennelRepository.UpdateShelterKennel(response);
                return response;
            }

            if (model.AnimalSizeInLbs >= smallSizeLimit && model.AnimalSizeInLbs <= mediumSizeLimit && kennelCapacity.MediumKennelCount > 0)
            {
                int assignedKennel = kennelCapacity.MediumVacantKennelIds[0];
                var response = new ShelterResponseModel
                {
                    IsAccepted = true,
                    KennelNumber = assignedKennel,
                    AnimalName = model.AnimalName,
                    Message = "Please proceed with sheltering the animal in kennel number:" + assignedKennel
                };
                _shelterKennelRepository.UpdateShelterKennel(response);
                return response;
            }

            if (model.AnimalSizeInLbs >= mediumSizeLimit && kennelCapacity.LargeKennelCount > 0)
            {
                int assignedKennel = kennelCapacity.LargeVacantKennelIds[0];
                var response = new ShelterResponseModel
                {
                    IsAccepted = true,
                    KennelNumber = assignedKennel,
                    AnimalName = model.AnimalName,
                    Message = "Please proceed with sheltering the animal in kennel number:" + assignedKennel
                };
                _shelterKennelRepository.UpdateShelterKennel(response);
                return response;
            }

            return new ShelterResponseModel
            {
                IsAccepted = false,
                KennelNumber = 0,
                Message = "We apologize but our kennels are currently full."
            };

        }


    }
}
