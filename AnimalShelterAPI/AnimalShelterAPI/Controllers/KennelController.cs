using AnimalShelter.Data.DataModels;
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
            var shelterKennelBOList = _shelterKennelRepository.GetShelterKennels();
            var shelterKennelResponseModelList = shelterKennelBOList.Select(x => new ShelterKennelResponseModel
            {
                KennelIdValue = x.KennelIdValue,
                KennelSize = (Size)x.KennelSize,
                IsOccupied = x.IsOccupied,
                ShelterAnimal = x.ShelterAnimal
            }).ToList();

            return Ok(shelterKennelResponseModelList);
        }

        [HttpPut]
        [Route("reorganizekennels")]
        public async Task<IActionResult> ReorganizeKennels()
        {
            return Ok(_reorganizeAnimalsService.ReorganizeAnimals());
        }
    }

}
