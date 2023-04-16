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

        public ShelterService(KennelCapacityService kennelCapacityService)
        {
            _kennelCapacityService = kennelCapacityService;
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
                    Message = "Animal size must be greater than 0 lbs. Are we providing shelter for an animal?"
                };
            }

            if (model.AnimalSizeInLbs <= smallSizeLimit && kennelCapacity.SmallKennelCountVacant > 0)
            {
                int assignedKennel = kennelCapacity.SmallVacantKennelIds[0];
                return new ShelterResponseModel
                {
                    IsAccepted = true,
                    KennelNumber = assignedKennel,
                    Message = "Please proceed with sheltering the animal in kennel number:" + assignedKennel
                };
            }

            if (model.AnimalSizeInLbs >= smallSizeLimit && model.AnimalSizeInLbs <= mediumSizeLimit && kennelCapacity.MediumKennelCount > 0)
            {
                int assignedKennel = kennelCapacity.MediumVacantKennelIds[0];
                return new ShelterResponseModel
                {
                    IsAccepted = true,
                    KennelNumber = assignedKennel,
                    Message = "Please proceed with sheltering the animal in kennel number:" + assignedKennel
                };
            }

            if (model.AnimalSizeInLbs >= mediumSizeLimit && kennelCapacity.LargeKennelCount > 0)
            {
                int assignedKennel = kennelCapacity.LargeVacantKennelIds[0];
                return new ShelterResponseModel
                {
                    IsAccepted = true,
                    KennelNumber = assignedKennel,
                    Message = "Please proceed with sheltering the animal in kennel number:" + assignedKennel
                };
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
