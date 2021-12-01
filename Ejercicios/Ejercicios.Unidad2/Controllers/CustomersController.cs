using Ejercicios.Unidad2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
