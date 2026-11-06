
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

        // INSERT / UPDATE CUSTOMER
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

        // GET ALL CUSTOMERS
        [HttpGet]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            try
            {
                var customers = await _customerService.GetAllCustomersAsync();

                var response = _mapper.Map<List<CustomerModel>>(customers);

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        // GET CUSTOMER BY ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomerByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Customer ID must be positive.");
                }

                var customer = await _customerService.GetCustomerByIdAsync(id);

                if (customer == null)
                {
                    return NotFound($"Customer with ID {id} was not found.");
                }

                var response = _mapper.Map<CustomerModel>(customer);

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
