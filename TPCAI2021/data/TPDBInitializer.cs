using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAI2021.data
{
    class TPDBInitializer : DropCreateDatabaseAlways<TPContext>
    {
        protected override void Seed(TPContext context)
        {
            // Seed provincias
                IList<Provincia> defaultProvincias = new List<Provincia>();

                defaultProvincias.Add(new Provincia() { ProvinciaID = 1, Nombre = "Antártida e Islas del Atlántico Sur", IdRegion = 2, Region = "Extremo Austral" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 2, Nombre = "Buenos Aires", IdRegion = 4, Region = "Buenos Aires" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 3, Nombre = "Catamarca", IdRegion = 7, Region = "Noroeste" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 4, Nombre = "Chaco", IdRegion = 8, Region = "Litoral" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 5, Nombre = "Chubut", IdRegion = 1, Region = "Patagonia" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 6, Nombre = "Ciudad Autónoma de Buenos Aires", IdRegion = 3, Region = "Ciudad Autónoma de Buenos Aires" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 7, Nombre = "Córdoba", IdRegion = 5, Region = "Sierras" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 8, Nombre = "Corrientes", IdRegion = 8, Region = "Litoral" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 9, Nombre = "Entre Ríos", IdRegion = 8, Region = "Litoral" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 10, Nombre = "Formosa", IdRegion = 8, Region = "Litoral" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 11, Nombre = "Jujuy", IdRegion = 7, Region = "Noroeste" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 12, Nombre = "La Pampa", IdRegion = 4, Region = "Buenos Aires" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 13, Nombre = "La Rioja", IdRegion = 7, Region = "Noroeste" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 14, Nombre = "Mendoza", IdRegion = 6, Region = "Cuyo" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 15, Nombre = "Misiones", IdRegion = 8, Region = "Litoral" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 16, Nombre = "Neuquen", IdRegion = 1, Region = "Patagonia" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 17, Nombre = "Rio Negro", IdRegion = 1, Region = "Patagonia" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 18, Nombre = "Salta", IdRegion = 7, Region = "Noroeste" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 19, Nombre = "San Juan", IdRegion = 6, Region = "Cuyo" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 20, Nombre = "San Luis", IdRegion = 6, Region = "Cuyo" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 21, Nombre = "Santa Cruz", IdRegion = 1, Region = "Patagonia" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 22, Nombre = "Santa Fe", IdRegion = 8, Region = "Litoral" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 23, Nombre = "Santiago del Estero", IdRegion = 7, Region = "Noroeste" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 24, Nombre = "Tierra del Fuego", IdRegion = 2, Region = "Extremo Austral" });
                defaultProvincias.Add(new Provincia() { ProvinciaID = 25, Nombre = "Tucumán", IdRegion = 7, Region = "Noroeste" });

                context.Provincias.AddRange(defaultProvincias);

            // Seed localidades
                IList<Localidad> defaultLocalidades = new List<Localidad>();
                int idLocalidad = 1;
                for (int i = 0; i < defaultProvincias.Count; i++)
                {
                    Provincia provincia = defaultProvincias[i];
                    for (int j = 0; j < 3; j++)
                    {
                        string nombre = "Localidad " + idLocalidad.ToString() + " de la provincia de " + provincia.Nombre;  
                        defaultLocalidades.Add(new Localidad() {LocalidadID = idLocalidad, Nombre = nombre, Provincia = provincia });
                        idLocalidad++;
                    }
                }
                context.Localidades.AddRange(defaultLocalidades);


            // Seed sucursales
                IList<Sucursal> defaultSucursales = new List<Sucursal>();
                int idSucursal = 1;
                for (int i = 0; i < defaultLocalidades.Count; i++)
                {
                    Localidad localidad = defaultLocalidades[i];
                    for (int j = 0; j < 3; j++)
                    {
                        string nombre = "Sucursal " + idSucursal.ToString() + " de la " + localidad.Nombre;
                        defaultSucursales.Add(new Sucursal() {SucursalID = idSucursal, Nombre = nombre, Localidad = localidad, Pais = null });
                        idSucursal++;
                    }
                }
                context.Sucursales.AddRange(defaultSucursales);

            // Seed paises

            IList<Pais> defaultPaises = new List<Pais>();
                defaultPaises.Add(new Pais() { PaisID = 1, Nombre = "Brasil", RegionID = 1, Region = "Paises limítrofes" });
                defaultPaises.Add(new Pais() { PaisID = 2, Nombre = "Chile", RegionID = 1, Region = "Paises limítrofes" });
                defaultPaises.Add(new Pais() { PaisID = 3, Nombre = "Uruguay", RegionID = 1, Region = "Paises limítrofes" });
                defaultPaises.Add(new Pais() { PaisID = 4, Nombre = "China", RegionID = 5, Region = "Asia" });
                defaultPaises.Add(new Pais() { PaisID = 5, Nombre = "Japón", RegionID = 5, Region = "Asia" });
                defaultPaises.Add(new Pais() { PaisID = 6, Nombre = "España", RegionID = 4, Region = "Europa" });
                defaultPaises.Add(new Pais() { PaisID = 7, Nombre = "Francia", RegionID = 4, Region = "Europa" });
                defaultPaises.Add(new Pais() { PaisID = 8, Nombre = "Inglaterra", RegionID = 4, Region = "Europa" });
                defaultPaises.Add(new Pais() { PaisID = 9, Nombre = "USA", RegionID = 3, Region = "América del Norte" });
                defaultPaises.Add(new Pais() { PaisID = 10, Nombre = "Mexico", RegionID = 3, Region = "América del Norte" });
                defaultPaises.Add(new Pais() { PaisID = 11, Nombre = "Canadá", RegionID = 3, Region = "América del Norte" });
                defaultPaises.Add(new Pais() { PaisID = 12, Nombre = "Colombia", RegionID = 2, Region = "Resto de América Latina" });
                defaultPaises.Add(new Pais() { PaisID = 13, Nombre = "Venezuela", RegionID = 2, Region = "Resto de América Latina" });
                defaultPaises.Add(new Pais() { PaisID = 14, Nombre = "Nicaragua", RegionID = 2, Region = "Resto de América Latina" });

                context.Paises.AddRange(defaultPaises);

                // Sucursales por pais
                IList<Sucursal> sucursalesPais = new List<Sucursal>();
                int idSucursalPais = defaultSucursales.Last().SucursalID + 1;
                for (int i = 0; i < defaultPaises.Count; i++)
                {
                    Pais pais = defaultPaises[i];
                    string nombre = "Sucursal de " + pais.Nombre;
                    sucursalesPais.Add(new Sucursal() { SucursalID = idSucursalPais, Nombre = nombre, Localidad = null, Pais = pais});
                    idSucursalPais++;
                    
                }
                context.Sucursales.AddRange(sucursalesPais);

            // Seed clientes
            IList<Cliente> defaultClientes = new List<Cliente>();
                defaultClientes.Add(new Cliente() {
                    ClienteID = 1,
                    NroClienteCorporativo = 00889222,
                    Saldo = 30,
                    Facturacion = "1",
                    ListaPersonalAutorizado = "123, 124, 125"
                });

                defaultClientes.Add(new Cliente()
                {
                    ClienteID = 2,
                    NroClienteCorporativo = 04,
                    Saldo = 3000,
                    Facturacion = "5",
                    ListaPersonalAutorizado = "123, 124, 125"
                });
            context.Clientes.AddRange(defaultClientes);

            // Seed Ordenes de Servicio
            IList<OrdenServicio> defaultOrdenesServicio = new List<OrdenServicio>();
            defaultOrdenesServicio.Add(new OrdenServicio()
            {
                Cliente = defaultClientes[1]
            });
            context.OrdenesServicio.AddRange(defaultOrdenesServicio);

            /*Console.WriteLine("id | Sucursal | Localidad");
            foreach (Sucursal sucu in defaultSucursales)
            {
                Console.WriteLine(sucu.SucursalID + "|" + sucu.Nombre + "|" + sucu.Localidad.Nombre);
            }
            Console.ReadLine();
            */

            base.Seed(context);

        }
    }
}
