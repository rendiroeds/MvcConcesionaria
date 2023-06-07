using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcConcesionaria.Models;

namespace MvcConcesionaria.Data
{
    public class MvcConcesionariaContext : DbContext
    {
        public MvcConcesionariaContext (DbContextOptions<MvcConcesionariaContext> options)
            : base(options)
        {
        }

        public DbSet<MvcConcesionaria.Models.Vehiculo> Vehiculo { get; set; } = default!;

        public DbSet<MvcConcesionaria.Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<MvcConcesionaria.Models.Venta> Venta { get; set; } = default!;
    }
}
