using AnimalShelter.Data.DataModels;
using AnimalShelter.Interfaces;
using AnimalShelter.Models.Business;
using AnimalShelter.Models.Presentation;
using System.Reflection;

namespace AnimalShelter.Data
{
    public class ShelterKennelRepository : IShelterKennelRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        
        public ShelterKennelRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        // dont return the Business Object, instead create a ResponseShelterKennelModel and then convert it to your BO.
        // either convert in controller, or make a method to convert.
        public List<ShelterKennelBO> GetShelterKennels()
        {
            using (var conn = _connectionFactory.CreateConnection())
            {
                // put your entity framework stuff here
                // or dapper
                // or whatever you're using
            }
            return new List<ShelterKennelBO> { };
        }

        public void UpdateShelterKennel(ShelterResponseModel response)
        {
            using (var conn = _connectionFactory.CreateConnection())
            {
                // put your entity framework stuff here
                // or dapper
                // or whatever you're using
            }
        }

        public void UpdateShelterKennel(AdoptionResponseModel response)
        {
            using (var conn = _connectionFactory.CreateConnection())
            {
                // put your entity framework stuff here
                // or dapper
                // or whatever you're using
            }
        }

        public void UpdateAllShelterKennels(List<ShelterKennelBO> list)
        {
            using (var conn = _connectionFactory.CreateConnection())
            {
                // put your entity framework stuff here
                // or dapper
                // or whatever you're using
            }
        }

        public void RemoveShelteredAnimal(AdoptionRequestModel model)
        {
            using (var conn = _connectionFactory.CreateConnection())
            {
                // put your entity framework stuff here
                // or dapper
                // or whatever you're using
            }
        }

        public bool IsAnimalSheltered(AdoptionRequestModel model)
        {
            using (var conn = _connectionFactory.CreateConnection())
            {
                // put your entity framework stuff here
                // or dapper
                // or whatever you're using
            }

            return true;
        }
    }
}
