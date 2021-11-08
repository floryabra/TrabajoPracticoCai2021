using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAI2021.data
{
    class TPContext : DbContext
    {
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public TPContext() : base()
        {
            Database.SetInitializer<TPContext>(new DropCreateDatabaseIfModelChanges<TPContext>());
        }
    }
}
