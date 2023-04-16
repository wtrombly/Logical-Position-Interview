using AnimalShelter.Interfaces;
using AnimalShelter.Models.Business;
using AnimalShelter.Models.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data
{
    public class ShelterKennelRepository : IShelterKennelRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ShelterKennelRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<ShelterKennelBO> GetShelterKennels(RequestShelterModel model)
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
    }
}
