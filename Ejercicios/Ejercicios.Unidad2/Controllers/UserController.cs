using Ejercicios.Unidad2.Models;
using Ejercicios.Unidad2.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicios.Unidad2.Controllers
{
    public class UserController : Controller
    {
        private VidlyDBContext _context;

        public UserController(VidlyDBContext context)
        {
            _context = context;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var customer = _context.Customer.Where(c => c.Email == viewModel.Email && c.Password == viewModel.Password).FirstOrDefault();

            if (customer == null)
                return View(viewModel);



            return RedirectToAction("Index", "Movies");
        }

        public IActionResult Register()
        {

            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()
                };

                return View("Register", viewModel);
            }

            _context.Customer.Add(customer);

            return RedirectToAction("Register");

        }

    }
}
