using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCAI2021.data;

namespace TPCAI2021
{
    class Pais
    {
        public int PaisID { get; set; }
        public string Nombre { get; set; }
        public int RegionID { get; set; }
        public string Region { get; set; }


        public static Pais getPais(int idPais)
        {
            var ctx = new TPContext();
            var paises = ctx.Paises;
            Pais pais = paises.Find(idPais);
            return pais;
        }

        public static void listarPaises(int idRegion = 0)
        {
            var ctx = new TPContext();
            IEnumerable<Pais> paises = null;

            if (idRegion == 0)
            {
                paises = ctx.Paises.ToList();
            }
            else
            {
                paises = ctx.Paises.Where(s => s.RegionID == idRegion)
                          .ToList();
            }

            Console.WriteLine("id | Pais | Region");
            foreach (Pais pais in paises)
            {
                Console.WriteLine(pais.PaisID + " | " + pais.Nombre + " | " + pais.Region);
            }
        }
    }
}
