using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ejercicios.Unidad2.Models
{
    public class VidlyDBContext : DbContext
    {
        public VidlyDBContext(DbContextOptions<VidlyDBContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MembershipType> MembershipType { get; set; }
    }
}
