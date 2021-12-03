using Ejercicios.Unidad2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Ejercicios.Unidad2.Controllers.Api
{

    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private VidlyDBContext _context;
        private IMapper _mapper;

        public MoviesController(VidlyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


    }
}
