using Ejercicios.Unidad2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicios.Unidad2.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Ejercicios.Unidad2.Controllers
{
    public class CustomersController : Controller
    {
        private VidlyDBContext _context;

        public CustomersController(VidlyDBContext context)
        {
            _context = context;
        }

        public IActionResult New()
        {
            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };
            ViewBag.Title = "New Customer";
        return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customer.Add(customer);
            }
            else
            {
                var customerIdDb = _context.Customer.Single(c => c.Id == customer.Id);

                //Mapper.Map(customer, customerInDb);

                customerIdDb.Name = customer.Name;
                customerIdDb.Birthdate = customer.Birthdate;
                customerIdDb.MembershipTypeId = customer.MembershipTypeId;
                customerIdDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public IActionResult Index()
        {
            var customers = _context.Customer.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        [Route("customers/details/{id}")]
        public IActionResult Details(int id)
        {
            Customer customer = _context.Customer.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);

            if(customer!=null)
                return View(customer);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return RedirectToAction("Index", "Customers");

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };
            ViewBag.Title=  "Edit Customer";
            return View("CustomerForm" , viewModel);
        }
    }
}
