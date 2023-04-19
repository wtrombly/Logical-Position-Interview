using AnimalShelter.Interfaces;
using AnimalShelter.Models;
using AnimalShelter.Models.Business;
using AnimalShelter.Models.Presentation;
using AnimalShelter.Services;

namespace AnimalShelterAPI.Services.Tests
{
    public class KennelStateServiceTests
    {
        public KennelStateService kennelStateService;
        public Mock<IKennelStateService> mockKennelStateService;

        [SetUp]
        public void SetUp()
        {
            kennelStateService = new KennelStateService();
            mockKennelStateService = new Mock<IKennelStateService>();

            ShelterAnimal animal = new ShelterAnimal
            {
                AnimalId = 1,
                AnimalName = "Test",
                AnimalSize = Size.Small
            };
        }

        [Test]
        public void SetShelterAnimal_ShelterAnimalPresent_IsOccupiedEqualsTrue()
        {
            //Arrange
            ShelterAnimal animal = new ShelterAnimal
            {
                AnimalId = 1,
                AnimalName = "Test",
                AnimalSize = Size.Small
            };

            ShelterKennelBO kennel = new ShelterKennelBO
            {
                KennelIdValue = 1,
                KennelSize = Size.Small,
                IsOccupied = false,
            };

            kennel.ShelterAnimal = animal;

            kennel.IsOccupied = false;

            //Act
            kennelStateService.SetShelterAnimal(kennel);

            //Assert
            Assert.IsTrue(kennel.IsOccupied);
        }
    }
}


