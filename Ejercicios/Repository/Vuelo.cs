using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    class Vuelo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string NumeroVuelo { get; set; }

        [Required]
        public DateTime HorarioLlegada { get; set; }

        [Required]
        public string LineaAerea { get; set; }
        public bool Demora { get; set; }
    }
}

