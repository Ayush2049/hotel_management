using HMT.Entities.Common;
using HMT.Entities.Customer;
using HMT.Repositories.Customer;

namespace HMT.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        public readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<MyResponse?> UpsertCustomerDetails(CustomerEntity entity)
        {
            return await _customerRepository.UpsertCustomerDetails(entity);
        }
    }
}
