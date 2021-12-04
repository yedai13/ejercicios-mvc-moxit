using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class CreateVueloModel
    {
        [Required(ErrorMessage = "El Número de vuelo es requerido")]
        [Display(Name = "Número de Vuelo")]
        public string NumeroVuelo { get; set; }

        [Required(ErrorMessage = "El horario de llegada es requerido")]
        [Display(Name = "Horario de llegada")]
        public DateTime HorarioLlegada { get; set; }

        [Required(ErrorMessage = "La linea aera es requerida")]
        [Display(Name = "Línea Aerea")]
        public string LineaAerea { get; set; }

        public bool Demora { get; set; }
        
    }
}
