
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

        // INSERT / UPDATE
        public async Task<MyResponse?> UpsertCustomerDetails(CustomerEntity entity)
        {
            using (var conn = CreateConnection())
            {
                await conn.OpenAsync();

                var parameters = new DynamicParameters();

                parameters.Add("@Id", entity.Id);
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

        // GET ALL CUSTOMERS
        public async Task<List<CustomerEntity>> GetAllCustomersAsync()
        {
            using (var conn = CreateConnection())
            {
                await conn.OpenAsync();

                var customers = await conn.QueryAsync<CustomerEntity>(
                    "[Customer].[GetAllCustomers]",
                    commandType: CommandType.StoredProcedure
                );

                return customers.ToList();
            }
        }

        // GET CUSTOMER BY ID
        public async Task<CustomerEntity?> GetCustomerByIdAsync(int id)
        {
            using (var conn = CreateConnection())
            {
                await conn.OpenAsync();

                var parameters = new DynamicParameters();

                parameters.Add("@Id", id);

                return await conn.QueryFirstOrDefaultAsync<CustomerEntity>(
                    "[Customer].[GetCustomerById]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}
