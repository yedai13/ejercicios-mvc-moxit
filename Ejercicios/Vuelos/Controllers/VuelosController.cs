using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository;
using Repository.Models;

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

        public IActionResult Create()
        {
            return View("VuelosForm");
        }

        [HttpPost]
        public IActionResult Create(CreateVueloModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Create", model);

            _vueloRepository.Create(model);

            return RedirectToAction("Index");
        }

        
        public IActionResult Edit(int id)
        {
            var vuelo = _vueloRepository.GetById(id);
            return View("Edit",vuelo);
        }

        [HttpPost]
        public ActionResult Edit(Vuelo vuelo)
        {
            _vueloRepository.Edit(vuelo);
            return RedirectToAction("Index");
        }
    }
}
