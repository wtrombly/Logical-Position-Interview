using AnimalShelter.Models.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Interfaces
{
    public interface IValidatorService
    {
        public bool ValidateShelterRequestModel(ShelterRequestModel model);
        public bool ValidateAnimalName(AdoptionRequestModel model);
    }
}
