using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int LocalidadID { get; set; }
        public virtual Localidad Localidad { get; set; }

        public static List<Sucursal> listaSucursales(int idProvinciaSolicitada = 0)
        {

            using (var r = new StreamReader("../../data/sucursales.csv"))
            {
                List<Sucursal> sucursales = new List<Sucursal>();
                string cabeceras = r.ReadLine();

                while (!r.EndOfStream)
                {
                    var line = r.ReadLine();
                    var values = line.Split(';');
                    int id_provincia = int.Parse(values[0]);
                    int id_sucursal = int.Parse(values[1]);
                    string nombre_sucursal = values[2];

                    if (idProvinciaSolicitada != 0 && id_provincia == idProvinciaSolicitada) {
                        //sucursales.Add(new Sucursal(id_provincia, id_sucursal, nombre_sucursal));
                    }

                }

                return sucursales;
            }

        }

        public static void agregarSucursal()
        {
            var ctx = new TPContext();
            Console.WriteLine("Ingrese el nombre de la nueva sucursal:");
            string nombreSucursal = Console.ReadLine();
            Console.WriteLine("Ingrese el código de localidad de la nueva sucursal:");
            int idLocalidad = int.Parse(Console.ReadLine());
            Localidad localidad = ctx.Localidades.Find(idLocalidad);

            var sucursal = new Sucursal() { Nombre = nombreSucursal, Localidad = localidad };
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

        public static void listarSucursales(int idLocalidadSolicitada = 0)
        {
            var ctx = new TPContext();
            var sucursales = ctx.Sucursales;
            if (idLocalidadSolicitada == 0)
            {
                sucursales.Include("Localidad").ToList();
            } else
            {
                sucursales.Where(s => s.Localidad.LocalidadID == idLocalidadSolicitada)
                          .Include("Localidad")
                          .ToList();
            }
            
            Console.WriteLine("id | Sucursal | Localidad");
            foreach (Sucursal sucu in sucursales)
            {
                Console.WriteLine(sucu.SucursalID + "|" + sucu.Nombre + "|" + sucu.Localidad.Nombre);
            }
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
