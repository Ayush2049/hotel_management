using AutoMapper;
using HMT.API.Models.Customers;
using HMT.Entities.Customer;

namespace HMT.API.Mapping
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CustomerModel, CustomerEntity>();
        }
    }
}