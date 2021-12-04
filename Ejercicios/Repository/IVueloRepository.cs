using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository
{
    public interface IVueloRepository
    {
        void Create(CreateVueloModel vuelo);
        void Edit(Vuelo vuelo);
        void Delete(Vuelo vuelo);
        IEnumerable<Vuelo> GetVuelos();
        Vuelo GetById(int id);
    }
}
