using AutoMapper;
using HMT.API.Models.Customers;
using HMT.Entities.Customer;

namespace HMT.API.Models.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Customer Mapping
            CreateMap<CustomerModel, CustomerEntity>();
            CreateMap<CustomerEntity, CustomerModel>();
            #endregion

        }
    }
}