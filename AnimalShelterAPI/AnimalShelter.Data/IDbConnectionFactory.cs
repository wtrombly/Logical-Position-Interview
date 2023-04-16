using System.Data;

namespace AnimalShelter.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}