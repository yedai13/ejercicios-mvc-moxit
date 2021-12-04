using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository;

namespace Vuelos.Controllers
{
    public class VuelosController : Controller
    {
        private IVueloRepository _vueloRepository;

        public VuelosController(IVueloRepository vueloRepository)
        {
            _vueloRepository = vueloRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Vuelo> vuelos = _vueloRepository.GetVuelos();
            return View(vuelos);
        }
    }
}
