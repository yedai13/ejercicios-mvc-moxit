using Ejercicios.Unidad2.Models;
using Ejercicios.Unidad2.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicios.Unidad2.Filter;

namespace Ejercicios.Unidad2.Controllers
{
    public class UserController : Controller
    {
        private VidlyDBContext _context;

        public UserController(VidlyDBContext context)
        {
            _context = context;
        }

        [NotLogged]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [NotLogged]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var customer = _context.Customer.Where(c => c.Email == viewModel.Email && c.Password == viewModel.Password).FirstOrDefault();

            if (customer == null)
                return View(viewModel);

            HttpContext.Session.SetInt32("TypeUser" , customer.TypeUser);
            HttpContext.Session.SetInt32("UserExist", 1);

            return RedirectToAction("Index", "Movies");
        }

        [Logged]
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
        [NotLogged]
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
            _context.SaveChanges();

            return RedirectToAction("Login");

        }

        [Logged]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "User");
        }

    }
}
