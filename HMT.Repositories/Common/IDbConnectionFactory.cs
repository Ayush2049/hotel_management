using System.Data;

namespace HMT.Repositories.Common
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}