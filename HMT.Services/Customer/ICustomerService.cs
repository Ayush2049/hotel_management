



using HMT.Entities.Common;
using HMT.Entities.Customer;

namespace HMT.Services.Customer
{
    public interface ICustomerService
    {
        // Insert / Update
        Task<MyResponse?> UpsertCustomerDetails(CustomerEntity entity);

        // Get All Customers
        Task<List<CustomerEntity>> GetAllCustomersAsync();

        // Get Customer By ID
        Task<CustomerEntity?> GetCustomerByIdAsync(int id);
    }
}
