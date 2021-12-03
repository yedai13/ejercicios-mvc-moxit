using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ejercicios.Unidad2.Models;
using System.Web.Http;
using AutoMapper;
using Ejercicios.Unidad2.Dtos;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;

namespace Ejercicios.Unidad2.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private VidlyDBContext _context;
        private IMapper _mapper;

        public CustomersController(VidlyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<CustomerDto> Get()
        {
            return _context.Customer.ToList().Select(_mapper.Map<Customer, CustomerDto>);
        }

        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(_mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        //TODO deberia usar IHttpActionResulta pero no funciona "return BadRequest()"
        public IActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customer.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            
            return Created(new Uri($"{Request.Path}/{customer.Id}", UriKind.Relative), customerDto);
        }

        [HttpPut]
        [Route("{id}")]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerIdDb = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customerIdDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _mapper.Map(customerDto, customerIdDb);
            
            //Se reemplaza por el mapeo
            // customerIdDb.Name = customerDto.Name;
            // customerIdDb.Birthdate = customerDto.Birthdate;
            // customerIdDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
            // customerIdDb.MembershipTypeId = customerDto.MembershipTypeId;


            _context.SaveChanges();
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteCustomer(int id)
        {
            var customerIdDb = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customerIdDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customer.Remove(customerIdDb);
            _context.SaveChanges();
        }

    }
}
