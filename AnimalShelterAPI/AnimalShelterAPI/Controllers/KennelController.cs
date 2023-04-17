using AnimalShelter.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KennelController : ControllerBase
    {
        private readonly IShelterKennelRepository _shelterKennelRepostory;

        public KennelController(IShelterKennelRepository shelterKennelRepostory)
        {
            _shelterKennelRepostory = shelterKennelRepostory;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetKennels()
        {
            return Ok(_shelterKennelRepostory.GetShelterKennels());
        }
    }
}
