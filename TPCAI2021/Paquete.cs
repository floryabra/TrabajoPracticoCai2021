using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAI2021
{
    class Paquete
    {
        public int idPaquete;
        public decimal peso;
        public string tipoPaquete;

        public Paquete(int idPaquete, decimal peso, string tipoPaquete)
        {
            this.idPaquete = idPaquete;
            this.peso = peso;
            this.tipoPaquete = tipoPaquete;
        }

        public string ingresarPaquete()
        {
            return "test ingresarPaquete()";
        }
    }
}
