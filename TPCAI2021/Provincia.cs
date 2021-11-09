using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCAI2021.data;

namespace TPCAI2021
{
    class Provincia
    {
        public int ProvinciaID { get; set; }
        public string Nombre { get; set; }
        public int IdRegion { get; set; }
        public string Region { get; set; }
        public ICollection<Localidad> Localidades { get; set; }

        public static Provincia getProvincia(int idProvincia)
        {
            var ctx = new TPContext();
            var provincias = ctx.Provincias;
            Provincia provincia = provincias.Find(idProvincia);
            return provincia;
        }

        public static void listarProvincias(int idRegion = 0)
        {
            var ctx = new TPContext();
            IEnumerable<Provincia> provincias = null;

            if (idRegion == 0)
            {
                provincias = ctx.Provincias.ToList();
            }
            else
            {
                provincias = ctx.Provincias.Where(s => s.IdRegion == idRegion)
                          .ToList();
            }

            Console.WriteLine("id | Provincia | Region");
            foreach (Provincia prov in provincias)
            {
                Console.WriteLine(prov.ProvinciaID+ "|" + prov.Nombre + "|" + prov.Region);
            }
        }
    }
}
