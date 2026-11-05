using Microsoft.Data.SqlClient;

namespace HMT.Repositories.Common
{
    public class BaseRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BaseRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        protected SqlConnection CreateConnection()
        {
            return (SqlConnection)_connectionFactory.CreateConnection();
        }
    }
}