using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class VuelosDbContext : DbContext
    {
        public VuelosDbContext(DbContextOptions<VuelosDbContext> options) : base(options)
        {

        }
        
        public DbSet<Vuelo> Vuelo { get; set; }
    }
}
