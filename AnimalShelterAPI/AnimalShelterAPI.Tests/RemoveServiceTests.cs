using AnimalShelter.Interfaces;
using AnimalShelter.Services;
using Moq;

namespace AnimalShelterAPI.Tests
{
    public class RemoveServiceTests
    {
        private RemoveService removeService;
        private Mock<IShelterKennelRepository> mockShelterKennelRepository;

        [SetUp]
        public void Setup()
        {
            mockShelterKennelRepository = new Mock<IShelterKennelRepository>();
            removeService = new RemoveService(mockShelterKennelRepository.Object);
        }

        [Test]
        public void RemoveAnimal_AnimalNameNull_FailedRemove()
        {
            Assert.Pass();
        }
    }
}