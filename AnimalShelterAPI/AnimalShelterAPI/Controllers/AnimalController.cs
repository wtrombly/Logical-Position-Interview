using AnimalShelter.Interfaces;
using AnimalShelter.Models.Presentation;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IShelterService _shelterService;
        private readonly IRemoveService _removeService;

        public AnimalController(IShelterService iShelterService)
        {
            _shelterService = iShelterService;
        }

        [HttpPost]
        [Route("Shelter")]
        public async Task<IActionResult> PlaceAnimal(ShelterRequestModel model)
        {
            return Ok(_shelterService.ShelterAnimal(model));
        }

        [HttpPut]
        [Route("Adopt")]
        public async Task<IActionResult> AdoptAnimal(AdoptionRequestModel model)
        {
            return Ok(_removeService.RemoveAnimal(model));
        }
    }
}
