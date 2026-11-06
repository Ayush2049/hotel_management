
using HMT.Entities.Common;
using HMT.Entities.Customer;
using HMT.Repositories.Customer;

namespace HMT.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // Insert / Update
        public async Task<MyResponse?> UpsertCustomerDetails(CustomerEntity entity)
        {
            return await _customerRepository.UpsertCustomerDetails(entity);
        }

        // Get All Customers
        public async Task<List<CustomerEntity>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        // Get Customer By ID
        public async Task<CustomerEntity?> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetCustomerByIdAsync(id);
        }
    }
}
