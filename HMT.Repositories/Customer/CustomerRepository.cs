using Dapper;
using HMT.Entities.Common;
using HMT.Entities.Customer;
using HMT.Repositories.Common;
using System.Data;

namespace HMT.Repositories.Customer
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(IDbConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
        }

        public async Task<MyResponse?> UpsertCustomerDetails(CustomerEntity entity)
        {
            using (var conn = CreateConnection())
            {
                await conn.OpenAsync();

                var parameters = new DynamicParameters();

                parameters.Add("@Name", entity.Name);
                parameters.Add("@Age", entity.Age);
                parameters.Add("@Email", entity.Email);
                parameters.Add("@PhoneNumber", entity.PhoneNumber);
                parameters.Add("@Address", entity.Address);

                return await conn.QueryFirstOrDefaultAsync<MyResponse>(
                    "[Customer].[UpsertCustomerDetails]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}