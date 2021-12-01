﻿using Ejercicios.Unidad2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicios.Unidad2.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customers = new()
        {
            new Customer() {Id = 1, Name = "Facundo", Surname = "Marin"},
            new Customer() {Id = 2, Name = "Willy", Surname = "Smith"},
            new Customer() {Id = 3, Name = "Mary", Surname = "Williams"},

        };

        public IActionResult Index()
        {
           
            return View(customers);
        }

        [Route("customers/details/{id}")]
        public IActionResult Details(int id)
        {
            Customer customer = customers.Where(c => c.Id == id).FirstOrDefault();

            return View(customer);
        }
    }
}
