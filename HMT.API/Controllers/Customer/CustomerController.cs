
using AutoMapper;
using HMT.API.Models.Customers;
using HMT.Entities.Customer;
using HMT.Services.Customer;
using Microsoft.AspNetCore.Mvc;

namespace HMT.API.Controllers.Customer
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(
            ICustomerService customerService,
            IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost("upsert")]
        public async Task<IActionResult> UpsertCustomerDetailsAsync(
            [FromBody] CustomerModel model)
        {
            try
            {
                CustomerEntity entity = _mapper.Map<CustomerEntity>(model);

                var data = await _customerService.UpsertCustomerDetails(entity);

                if (data == null)
                {
                    return StatusCode(500, "No response received from database.");
                }

                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
