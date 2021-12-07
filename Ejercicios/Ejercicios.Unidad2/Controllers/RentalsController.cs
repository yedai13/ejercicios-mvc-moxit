using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicios.Unidad2.Filter;

namespace Ejercicios.Unidad2.Controllers
{
    [IsAdmin]
    public class RentalsController : Controller
    {
        public IActionResult New()
        {
            return View();
        }
    }
}
