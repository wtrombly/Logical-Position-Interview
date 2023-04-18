using AnimalShelter.Interfaces;
using AnimalShelter.Models.Presentation;
using AnimalShelter.Services;

namespace AnimalShelterAPI.Services.Tests
{
    public class ValidatorServiceTests
    {
        public ValidatorService validatorService;

        [SetUp]
        public void SetUp()
        {
            validatorService = new ValidatorService();
        }

        [Test]
        public void ValidateAnimalName_WhenAnimalNameIsNull_ReturnFalse()
        {   //Arrange
            var model = new AdoptionRequestModel { AnimalName = null };
            //Act
            var result = validatorService.ValidateAnimalName(model);
            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateAnimalName_WhenAnimalNameIsNotNull_ReturnTrue()
        {
            //Arrange
            var model = new AdoptionRequestModel { AnimalName = "Max" };
            //Act
            var result = validatorService.ValidateAnimalName(model);
            //Assert
            Assert.IsTrue(result);
        }
    }

    
}
