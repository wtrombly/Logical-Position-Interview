using AnimalShelter.Interfaces;
using AnimalShelter.Models.Presentation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IShelterService _shelterService;

        public AnimalController(IShelterService iShelterService)
        {
            _shelterService = iShelterService;
        }

        [HttpPost]
        [Route("ShelterAnimal")]

        public async Task<IActionResult> PlaceAnimal(RequestShelterModel model)
        {
            return Ok(_shelterService.ShelterAnimal(model));
        }

    }
}
