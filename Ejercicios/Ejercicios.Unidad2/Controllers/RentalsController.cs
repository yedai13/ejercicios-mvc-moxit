﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicios.Unidad2.Controllers
{
    public class RentalsController : Controller
    {
        public IActionResult New()
        {
            return View();
        }
    }
}
