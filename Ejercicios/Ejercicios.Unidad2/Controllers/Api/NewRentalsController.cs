using Ejercicios.Unidad2.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejercicios.Unidad2.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewRentalsController : ControllerBase
    {

        [HttpPost]
        public IActionResult CreateNewRentals(NewRentalDto newRental)
        {
            return null;
        }
    }
}
