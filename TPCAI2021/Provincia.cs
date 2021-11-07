﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAI2021
{
    class Provincia
    {
        public int idProvincia;
        public string nombreProvincia;
        public int idRegion;
        public string nombreRegion;

        public Provincia(int idProvincia, string nombreProvincia, int idRegion, string nombreRegion)
        {
            this.idProvincia = idProvincia;
            this.nombreProvincia = nombreProvincia;
            this.idRegion = idRegion;
            this.nombreRegion = nombreRegion;
        }

        public static List<Provincia> listaProvincias()
        {

            using (var r = new StreamReader("../../data/provincias_regiones.csv"))
            {
                List<Provincia> provincias = new List<Provincia>();
                string cabeceras = r.ReadLine();

                while (!r.EndOfStream)
                {
                        var line = r.ReadLine();
                        var values = line.Split(';');
                        int id_provincia = int.Parse(values[0]);
                        string nombre_provincia = values[1];
                        int id_region = int.Parse(values[2]);
                        string nombre_region = values[1];
                        provincias.Add(new Provincia(id_provincia, nombre_provincia, id_region, nombre_region));
                        
                }

                return provincias;
            }

        }
    }
}