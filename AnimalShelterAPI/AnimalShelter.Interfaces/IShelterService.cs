using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalShelter.Models.Presentation;


namespace AnimalShelter.Interfaces
{
    public interface IShelterService
    {
        ResponseShelterModel ShelterAnimal(RequestShelterModel model);
    }
}
