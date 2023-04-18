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
    public class SwapAnimalServiceTests
    {
        public SwapAnimalService swapAnimalService;
        public Mock<IKennelStateService> mockKennelStateService;

        [SetUp]
        public void SetUp()
        {
            mockKennelStateService = new Mock<IKennelStateService>();

            // Set up the mock behavior for SetShelterAnimal method
            mockKennelStateService.Setup(service => service.SetShelterAnimal(It.IsAny<ShelterKennelBO>()))
                .Callback<ShelterKennelBO>(kennel => kennel.IsOccupied = kennel.ShelterAnimal != null);

            swapAnimalService = new SwapAnimalService(mockKennelStateService.Object); ;
        }

        [Test]
        public void SwapAnimal_CheckLargeKennelsForSmallAnimals_MoveSmall()
        {
            //Arrange
            var kennels = new List<ShelterKennelBO>
            {
                new ShelterKennelBO { KennelIdValue = 1, KennelSize = Size.Small, IsOccupied = false },
                new ShelterKennelBO { KennelIdValue = 2, KennelSize = Size.Medium, IsOccupied = true, ShelterAnimal = new TestShelterAnimal { AnimalSize = Size.Small } },
                new ShelterKennelBO { KennelIdValue = 3, KennelSize = Size.Medium, IsOccupied = false }
            };

            //Act
            swapAnimalService.SwapAnimal(kennels, Size.Small, Size.Small, Size.Small);

            //Assert
            Assert.IsFalse(kennels[0].IsOccupied);
        }

        [Test]
        public void SwapAnimal_CheckLargeKennelsForSmallAnimals_MoveNextBestSize()
        {
            //Arrange
            var kennels = new List<ShelterKennelBO>
            {
                new ShelterKennelBO { KennelIdValue = 1, KennelSize = Size.Small, IsOccupied = true, ShelterAnimal = new TestShelterAnimal { AnimalSize = Size.Small } },
                new ShelterKennelBO { KennelIdValue = 2, KennelSize = Size.Small, IsOccupied = true, ShelterAnimal = new TestShelterAnimal { AnimalSize = Size.Small } },
                new ShelterKennelBO { KennelIdValue = 3, KennelSize = Size.Medium, IsOccupied = false },
                new ShelterKennelBO { KennelIdValue = 4, KennelSize = Size.Large, IsOccupied = true, ShelterAnimal = new TestShelterAnimal { AnimalSize = Size.Small, AnimalName = "Max"} },
                new ShelterKennelBO { KennelIdValue = 5, KennelSize = Size.Large, IsOccupied = false }
                
            };

            //Act
            swapAnimalService.SwapAnimal(kennels, Size.Large, Size.Small, Size.Small);

            //Assert
            Assert.IsTrue(kennels[2].IsOccupied);
            Assert.IsFalse(kennels[3].IsOccupied);
        }

        [Test]
        public void SwapAnimal_CheckMediumKennelsForSmallAnimals_MoveSmall()
        {
            //Arrange
            var kennels = new List<ShelterKennelBO>
            {
                new ShelterKennelBO { KennelIdValue = 1, KennelSize = Size.Small, IsOccupied = true, ShelterAnimal = new TestShelterAnimal { AnimalSize = Size.Small } },
                new ShelterKennelBO { KennelIdValue = 2, KennelSize = Size.Small, IsOccupied = false },
                new ShelterKennelBO { KennelIdValue = 3, KennelSize = Size.Medium, IsOccupied = false },
                new ShelterKennelBO { KennelIdValue = 4, KennelSize = Size.Medium, IsOccupied = true, ShelterAnimal = new TestShelterAnimal { AnimalSize = Size.Small, AnimalName = "Max"} },
                new ShelterKennelBO { KennelIdValue = 5, KennelSize = Size.Large, IsOccupied = false }

            };

            //Act
            swapAnimalService.SwapAnimal(kennels, Size.Medium, Size.Small, Size.Small);

            //Assert
            Assert.IsTrue(kennels[1].IsOccupied);
            Assert.IsFalse(kennels[3].IsOccupied);
        }
        
        [Test]
        public void SwapAnimal_CheckLargeKennelsForMediumAnimals_MoveMedium()
        {
            //Arrange
            var kennels = new List<ShelterKennelBO>
            {
                new ShelterKennelBO { KennelIdValue = 1, KennelSize = Size.Small, IsOccupied = true, ShelterAnimal = new TestShelterAnimal { AnimalSize = Size.Small } },
                new ShelterKennelBO { KennelIdValue = 2, KennelSize = Size.Small, IsOccupied = false },
                new ShelterKennelBO { KennelIdValue = 3, KennelSize = Size.Medium, IsOccupied = false },
                new ShelterKennelBO { KennelIdValue = 4, KennelSize = Size.Large, IsOccupied = true, ShelterAnimal = new TestShelterAnimal { AnimalSize = Size.Medium, AnimalName = "Maxamillian"} },
                new ShelterKennelBO { KennelIdValue = 5, KennelSize = Size.Large, IsOccupied = false }
            };

            //Act
            swapAnimalService.SwapAnimal(kennels, Size.Large, Size.Medium, Size.Medium);

            //Assert
            Assert.IsTrue(kennels[2].IsOccupied);
            Assert.IsFalse(kennels[3].IsOccupied);
        }
    }

    public class TestShelterAnimal : IShelterAnimal
    {
        public Size AnimalSize { get; set; }
        public string AnimalName { get; set; }
        public long AnimalId { get; set; }
    }

}
