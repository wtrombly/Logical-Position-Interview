using AnimalShelter.Interfaces;
using AnimalShelter.Models.Business;
using AnimalShelter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelterAPI.Services.Tests
{
    public class ReorganizeAnimalsServiceTests
    {
        public ReorganizeAnimalsService reorganizeAnimalsService;
        public Mock<IShelterKennelRepository> mockShelterKennelRepository;
        public Mock<ISwapAnimalService> mockSwapAnimalService;

        [SetUp]
        public void SetUp()
        {
            mockShelterKennelRepository = new Mock<IShelterKennelRepository>();
            mockSwapAnimalService = new Mock<ISwapAnimalService>();

            // Set up the mock behavior for GetShelterKennels method
            var mockShelterKennelList = new List<ShelterKennelBO>();
            mockShelterKennelRepository.Setup(service => service.GetShelterKennels()).Returns(mockShelterKennelList);

            //Set up the mock behavior for SwapAnimalService
            var mockSwapAnimalsShelterKennelList = new List<ShelterKennelBO>();
            mockSwapAnimalService.Setup(service => service.SwapAnimal(mockShelterKennelList, Size.Large, Size.Small, Size.Small));

            reorganizeAnimalsService = new ReorganizeAnimalsService(mockShelterKennelRepository.Object,mockSwapAnimalService.Object);
        }
    }
}
