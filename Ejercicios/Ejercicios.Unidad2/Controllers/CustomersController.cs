﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicios.Unidad2.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
