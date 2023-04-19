using AnimalShelter.Interfaces;
using AnimalShelter.Models.Business;
using AnimalShelter.Models.Presentation;
using AnimalShelter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelterAPI.Services.Tests
{
    public class RemoveServiceTests
    {
        public RemoveService removeService;
        public ValidatorService validatorService;
        public Mock<IShelterKennelRepository> mockShelterKennelRepository;
        public Mock<IValidatorService> mockValidatorService;

        [SetUp]
        public void SetUp()
        {
            mockShelterKennelRepository = new Mock<IShelterKennelRepository>();
            mockValidatorService = new Mock<IValidatorService>();
            removeService = new RemoveService(mockShelterKennelRepository.Object, mockValidatorService.Object);
            var model = new AdoptionRequestModel();

            // Set up the mock behavior for RemoveShelteredAnimal method
            mockShelterKennelRepository.Setup(service => service.RemoveShelteredAnimal(model));
        }

        [Test]
        public void RemoveAnimal_AnimalNotExist_IsRemovedFalse()
        {
            //Arrange
            var model = new AdoptionRequestModel();
            //Set up the mock behavior for the ValidateAnimalName method
            mockValidatorService.Setup(service => service.ValidateAnimalName(model)).Returns(true);

            //Set up the mock behavior for the IsAnimalSheltered method
            mockShelterKennelRepository.Setup(service => service.IsAnimalSheltered(model)).Returns(false);

            AdoptionResponseModel response = new AdoptionResponseModel
            {
                IsRemoved = false,
                KennelId = null,
                AnimalName = model.AnimalName,
                Message = "Unable to find animal with animal name:" + model.AnimalName
            };

            //Act
            var result = removeService.RemoveAnimal(model);

            //Assert
            Assert.AreEqual(response.AnimalName, result.AnimalName);
            Assert.AreEqual(response.IsRemoved, result.IsRemoved);
            Assert.AreEqual(response.KennelId, result.KennelId);
            Assert.AreEqual(response.Message, result.Message);

        }

        [Test]
        public void RemoveAnimal_AnimalThatExists_IsRemovedTrue()
        {
            //Arrange
            var model = new AdoptionRequestModel
            {
                AnimalType = "Dog",
                AnimalName = "Max",
                AnimalSizeInLbs = 15
            };
            //Set up the mock behavior for the ValidateAnimalName method
            mockValidatorService.Setup(service => service.ValidateAnimalName(model)).Returns(true);

            //Set up the mock behavior for the IsAnimalSheltered method
            mockShelterKennelRepository.Setup(service => service.IsAnimalSheltered(model)).Returns(true);

            AdoptionResponseModel response = new AdoptionResponseModel
            {
                IsRemoved = true,
                KennelId = null,
                AnimalName = model.AnimalName,
                Message = "The animal has been adopted."
            };

            //Act
            var result = removeService.RemoveAnimal(model);

            //Assert
            Assert.AreEqual(response.AnimalName, result.AnimalName);
            Assert.AreEqual(response.IsRemoved, result.IsRemoved);
            Assert.AreEqual(response.KennelId, result.KennelId);
            Assert.AreEqual(response.Message, result.Message);

        }
    }
}
