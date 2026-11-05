using HMT.Entities.Common;
using HMT.Entities.Customer;

namespace HMT.Repositories.Customer
{
    public interface ICustomerRepository
    {
        Task<MyResponse?> UpsertCustomerDetails(CustomerEntity entity);
    }
}