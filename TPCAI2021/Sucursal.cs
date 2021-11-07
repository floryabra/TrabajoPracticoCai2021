using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAI2021
{
    class Sucursal
    {
        public int idProvincia;
        public int idSucursal;
        public int nombre;
        public Sucursal(int idProvincia, int idSucursal, int nombre)
        {
            this.idProvincia = idProvincia;
            this.idSucursal = idSucursal;
            this.nombre = nombre;
        }
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
                        sucursales.Add(new Sucursal(id_provincia, id_sucursal, nombre_sucursal));
                    }

                }

                return sucursales;
            }

        }
    }
}
