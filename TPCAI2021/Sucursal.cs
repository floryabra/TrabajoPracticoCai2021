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

    }
}
