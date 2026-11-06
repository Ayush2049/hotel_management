
using HMT.Entities.Common;
using HMT.Entities.Customer;

namespace HMT.Repositories.Customer
{
    public interface ICustomerRepository
    {
        // Insert / Update
        Task<MyResponse?> UpsertCustomerDetails(CustomerEntity entity);

        // Get All Customers
        Task<List<CustomerEntity>> GetAllCustomersAsync();

        // Get Customer By ID
        Task<CustomerEntity?> GetCustomerByIdAsync(int id);
    }
}
