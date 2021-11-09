using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCAI2021.data;

namespace TPCAI2021
{
    [Table("Localidades")]
    class Localidad
    {
        public int LocalidadID { get; set; }
        public string Nombre { get; set; }

        public int ProvinciaID { get; set; }
        public virtual Provincia Provincia { get; set; }
        public ICollection<Sucursal> Sucursales { get; set; }


        public static Localidad getLocalidad(int idLocalidad)
        {
            var ctx = new TPContext();
            var localidades = ctx.Localidades;
            Localidad localidad = localidades.Find(idLocalidad);
            return localidad;
        }

        public static void listarLocalidades(int idProvinciaSeleccionada = 0)
        {
            var ctx = new TPContext();
            IEnumerable<Localidad> localidades = null;

            if (idProvinciaSeleccionada == 0)
            {
                localidades = ctx.Localidades.Include("Provincia").ToList();
            }
            else
            {
                localidades = ctx.Localidades.Where(s => s.ProvinciaID == idProvinciaSeleccionada)
                           .Include("Provincia")
                          .ToList();
            }

            Console.WriteLine("id | Localidad | Provincia");
            foreach (Localidad loc in localidades)
            {
                Console.WriteLine(loc.LocalidadID + "|" + loc.Nombre + "|" + loc.Provincia.Nombre);
            }
        }
    }
}
