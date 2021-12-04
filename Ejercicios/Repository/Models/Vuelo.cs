﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Vuelo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Número de Vuelo")]
        public string NumeroVuelo { get; set; }

        [Required]
        [Display(Name = "Horario de llegada")]
        public DateTime HorarioLlegada { get; set; }

        [Required]
        [Display(Name = "Línea Aerea")]
        public string LineaAerea { get; set; }
        public bool Demora { get; set; }
    }
}

