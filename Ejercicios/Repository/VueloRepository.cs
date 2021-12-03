using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class VueloRepository : IVueloRepository
    {
        private VuelosDbContext _ctx;

        public VueloRepository(VuelosDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Create(Vuelo vuelo)
        {
            Vuelo nuevo = new();
            nuevo.NumeroVuelo = vuelo.NumeroVuelo;
            nuevo.LineaAerea = vuelo.LineaAerea;
            nuevo.HorarioLlegada = vuelo.HorarioLlegada;
            nuevo.Demora = vuelo.Demora;

            _ctx.Vuelo.Add(nuevo);
            _ctx.SaveChanges();
        }

        public void Delete(Vuelo vuelo)
        {
            _ctx.Remove(vuelo);
            _ctx.SaveChanges();
        }

        public void Edit(Vuelo vuelo)
        {
            _ctx.Update(vuelo);
            _ctx.SaveChanges();
        }

        public Vuelo GetById(int id)
        {
            return _ctx.Vuelo.Where(v => v.Id == id).FirstOrDefault();
        }

        public IEnumerable<Vuelo> GetVuelos()
        {
            return _ctx.Vuelo.OrderBy(v => v.HorarioLlegada).ToList();
        }

        //     public IList<Vuelo> GetVuelos()
        //     {
        //         return _ctx.Vuelos.OrderBy(v => v.HorarioLlegada).Select(x => new VueloModel(x)).ToList();
        //     }
        // }

    }
}
