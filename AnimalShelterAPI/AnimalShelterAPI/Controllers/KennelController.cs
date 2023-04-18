using AnimalShelter.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KennelController : ControllerBase
    {
        private readonly IShelterKennelRepository _shelterKennelRepository;
        private readonly IReorganizeAnimalsService _reorganizeAnimalsService;

        public KennelController(IShelterKennelRepository shelterKennelRepository, IReorganizeAnimalsService reorganizeAnimalsService)
        {
            _shelterKennelRepository = shelterKennelRepository;
            _reorganizeAnimalsService = reorganizeAnimalsService;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetKennels()
        {
            return Ok(_shelterKennelRepository.GetShelterKennels().Select(x => new );
        }

        [HttpPut]
        [Route("reorganizekennels")]
        public async Task<IActionResult> ReorganizeKennels()
        {
            return Ok(_reorganizeAnimalsService.ReorganizeAnimals());
        }
    }

}
