using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCAI2021.data;

namespace TPCAI2021
{
    [Table("Sucursales")]
    class Sucursal
    {
        public int SucursalID { get; set; }
        public string Nombre { get; set; }

        public int? LocalidadID { get; set; }
        public virtual Localidad Localidad { get; set; }

        public int? PaisID { get; set; }
        public virtual Pais Pais { get; set; }

        public static void agregarSucursal()
        {
            var ctx = new TPContext();
            Console.WriteLine("Ingrese el nombre de la nueva sucursal:");
            string nombreSucursal = Console.ReadLine();
            Localidad localidad = null;
            Pais pais = null;

            Console.WriteLine("¿La sucursal es nacional? S/N");
            string tipoSucursal = Console.ReadLine();

            if (tipoSucursal == "s")
            {
                Console.WriteLine("Ingrese el código de localidad de la nueva sucursal:");
                int idLocalidad = int.Parse(Console.ReadLine());
                localidad = ctx.Localidades.Find(idLocalidad);
            } else
            {
                Console.WriteLine("Ingrese el código del pais:");
                int idPais = int.Parse(Console.ReadLine());
                pais = ctx.Paises.Find(idPais);
            }

            

            var sucursal = new Sucursal() { Nombre = nombreSucursal, Localidad = localidad, Pais = pais};
            ctx.Sucursales.Add(sucursal);
            ctx.SaveChanges();
            Console.WriteLine("Sucursal agregada.");
        }

        public static void eliminarSucural()
        {
            var ctx = new TPContext();

            Console.WriteLine("Ingrese el id de la sucursal a eliminar:");

            int idSucursal = int.Parse(Console.ReadLine());
            Sucursal sucursal = ctx.Sucursales.Find(idSucursal);

            ctx.Sucursales.Remove(sucursal);
            ctx.SaveChanges();

            Console.WriteLine("Sucursal eliminada");
        }

        public static void listarSucursales(int idLocalidadSolicitada = 0, int idPaisSolicitado = 0)
        {
            var ctx = new TPContext();
            IEnumerable<Sucursal> sucursales = null;

            if (idLocalidadSolicitada == 0 && idPaisSolicitado == 0)
            {
                sucursales = ctx.Sucursales.Include("Localidad").Include("Pais").ToList();
            } else if (idLocalidadSolicitada != 0)
            {
                sucursales = ctx.Sucursales.Where(s => s.LocalidadID == idLocalidadSolicitada)
                          .Include(s => s.Localidad)
                          .ToList();
            } else if (idPaisSolicitado != 0)
            {
                sucursales = ctx.Sucursales.Where(s => s.PaisID == idPaisSolicitado)
                          .Include(s => s.Pais)
                          .ToList();
            }

            Console.WriteLine("-----------");
            Console.WriteLine("id | Sucursal | Ubicacion");
            Console.WriteLine("-----------");

            foreach (Sucursal sucu in sucursales)
            {
                string ubicacion = "";
                if (sucu.Localidad == null)
                {
                    ubicacion = sucu.Pais.Region;
                } else if (sucu.Pais == null)
                {
                    ubicacion = sucu.Localidad.Nombre;
                }
                Console.WriteLine(sucu.SucursalID + " | " + sucu.Nombre + " | " + ubicacion);
            }
        }

        public static Sucursal getSucursal(int idSucursal)
        {
            var ctx = new TPContext();
            var sucursales= ctx.Sucursales;
            Sucursal sucursal = sucursales.Find(idSucursal);
            return sucursal;
        }


        public static void menuABM()
        {
            List<string> menuItems = new List<string>()
            {
                "Agregar sucursal",
                "Eliminar sucursal",
                "Listar sucursales"
            };

            while (true)
            {
                
                string opcionSeleccionada = Program.mostrarMenu(menuItems);

                if (opcionSeleccionada == "Agregar sucursal")
                {
                    agregarSucursal();
                }
                else if (opcionSeleccionada == "Eliminar sucursal")
                {
                    eliminarSucural();
                }
                else if (opcionSeleccionada == "Listar sucursales") 
                {
                    listarSucursales();
                }
                else if (opcionSeleccionada == "Salir")
                {
                    break;
                }
                Console.ReadKey();
            }
        }
    }
}
