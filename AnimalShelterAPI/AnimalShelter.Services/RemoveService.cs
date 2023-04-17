using AnimalShelter.Interfaces;
using AnimalShelter.Models.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class RemoveService
    {
        private readonly IShelterKennelRepository _shelterKennelRepository;
        public RemoveService(IShelterKennelRepository shelterKennelRepository)
        {
            _shelterKennelRepository = shelterKennelRepository;
        }

        public ResponseRemoveModel RemoveAnimal(RequestShelterModel model)
        {
            var response = new ResponseRemoveModel
            {
                IsRemoved = true,
                KennelId = null,
                AnimalName = model.AnimalName,
                Message = "The animal has been removed from the kennel."
            };
            _shelterKennelRepository.UpdateShelterKennel(response);
            return response;
        }
    }
}
