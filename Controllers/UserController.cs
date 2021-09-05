using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CSharpApi.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpApi.Data;
using CSharpApi.Commons;
using Microsoft.EntityFrameworkCore;

namespace CSharpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private WomenTechstersDBContext _dbContext;

        public UserController(WomenTechstersDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetUsers")]
        public IActionResult Get()
        {
            try
            {
                var customers = _dbContext.customer.ToList();

                if(customers.Count == 0)
                {
                    return StatusCode(404, "No customer found");
                }
                return Ok(customers);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occured "+e.Message);
            }
            
        }

        [HttpPost("CreateUser")]
        public IActionResult Create([FromBody] CustomerRequest customerRequest)
        {
            try
            {
                Customer customer = new Customer();
                customer.FirstName = customerRequest.FirstName;
                customer.Email = customerRequest.Email;
                customer.LastName = customerRequest.LastName;
                customer.PhoneNumber = customerRequest.PhoneNumber;
                customer.CustomerPassword = EncryptionUtilities.EncryptString(customerRequest.CustomerPassword);

                _dbContext.customer.Add(customer);
                _dbContext.SaveChanges();

                var customers = _dbContext.customer.ToList();
                return Ok(customers);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occured " + e.Message);
            }

        }

        [HttpPut("UpdateUser")]
        public IActionResult Update([FromBody] CustomerRequest customerRequest)
        {
            try
            {
                var customer = _dbContext.customer.FirstOrDefault(x=>x.CustomerId==customerRequest.CustomerId);
                if (customer == null)
                {
                    return StatusCode(404, "No customer found");
                }

                customer.FirstName = customerRequest.FirstName;
                customer.Email = customerRequest.Email;
                customer.LastName = customerRequest.LastName;
                customer.PhoneNumber = customerRequest.PhoneNumber;
                customer.CustomerPassword = EncryptionUtilities.EncryptString(customerRequest.CustomerPassword);

                _dbContext.Entry(customer).State = EntityState.Modified;
                _dbContext.SaveChanges();

                var customers = _dbContext.customer.ToList();
                return Ok(customers);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occured " + e.Message);
            }

        }


        [HttpDelete("DeleteUser/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            try
            {
                var customer = _dbContext.customer.FirstOrDefault(x => x.CustomerId == Id);
                if (customer == null)
                {
                    return StatusCode(404, "No customer found");
                }

                
                _dbContext.Entry(customer).State = EntityState.Deleted;
                _dbContext.SaveChanges();

                var customers = _dbContext.customer.ToList();
                return Ok(customers);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occured " + e.Message);
            }
        }
    }
}
