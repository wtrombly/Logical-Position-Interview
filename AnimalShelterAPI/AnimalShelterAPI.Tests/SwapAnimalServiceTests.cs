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

        [SetUp]
        public void SetUp()
        {
            swapAnimalService = new SwapAnimalService();
        }

        [Test]
        public void SwapAnimal_VacantKennelOfExactSize_Available()
        {
            //Arrange
            var kennels = new List<ShelterKennelBO>
            {
                new ShelterKennelBO { KennelIdValue = 1, KennelSize = Size.Small, IsOccupied = false },
                new ShelterKennelBO { KennelIdValue = 2, KennelSize = Size.Small, IsOccupied = true, ShelterAnimal = new TestShelterAnimal { AnimalSize = Size.Small } },
                new ShelterKennelBO { KennelIdValue = 3, KennelSize = Size.Medium, IsOccupied = false }
            };

            //Act
            swapAnimalService.SwapAnimal(kennels, Size.Small, Size.Small, Size.Small);

            //Assert
            Assert.IsFalse(kennels[0].IsOccupied);
        }
    }

    public class TestShelterAnimal : IShelterAnimal
    {
        public Size AnimalSize { get; set; }
        public string AnimalName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long AnimalId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        // Add other required properties and methods based on the IShelterAnimal interface
    }

}
