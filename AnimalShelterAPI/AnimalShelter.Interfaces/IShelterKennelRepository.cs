using AnimalShelter.Models.Business;
using AnimalShelter.Models.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Interfaces
{
    public interface IShelterKennelRepository
    {
        public List<ShelterKennelBO> GetShelterKennels();

        public void UpdateShelterKennel(ResponseShelterModel response);
        public void UpdateShelterKennel(ResponseRemoveModel response);
    }
}
