using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Ejercicios.Unidad2.Models;
using System.Web.Http;
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

        public CustomersController(VidlyDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> Get()
        {
            return _context.Customer.ToList();
        }

        [Route("{id}")]
        public Customer Get(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customer.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerIdDb = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customerIdDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerIdDb.Name = customer.Name;
            customerIdDb.Birthdate = customer.Birthdate;
            customerIdDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerIdDb.MembershipTypeId = customer.MembershipTypeId;


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
