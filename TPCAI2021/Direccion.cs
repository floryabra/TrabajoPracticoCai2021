using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAI2021
{
    class Direccion
    {
        public bool alcanceNacional;
        public string provincia;
        public string ciudad;
        public string calle;
        public int codigoPostal;
        public int? piso;
        public char? depto;

        public Direccion(bool alcanceNacional, string provincia, string ciudad, string calle, int codigoPostal, int? piso, char? depto)
        {
            this.alcanceNacional = alcanceNacional;
            this.provincia = provincia;
            this.ciudad = ciudad;
            this.calle = calle;
            this.codigoPostal = codigoPostal;
            this.piso = piso;
            this.depto = depto;
        }

        public string ingresarDireccion()
        {
            return "test ingresarDireccion";
        }
    }
}
