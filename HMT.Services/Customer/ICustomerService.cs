using HMT.Entities.Common;
using HMT.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMT.Services.Customer
{
    public interface ICustomerService
    {
        Task<MyResponse?> UpsertCustomerDetails(CustomerEntity entity);
    }
}
