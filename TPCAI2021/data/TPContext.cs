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
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<OrdenServicio> OrdenesServicio { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }

        public TPContext() : base("TPDB")
        {
            Database.SetInitializer(new TPDBInitializer());
        }
    }
}
