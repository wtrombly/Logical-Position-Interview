using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AnimalShelter.Data
{
    public class AnimalShelterConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;
        private const string c_connectionStringSection = "ConnectionStrings:AnimalShelterDbConnectionString";

        public AnimalShelterConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection(c_connectionStringSection).Value;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
