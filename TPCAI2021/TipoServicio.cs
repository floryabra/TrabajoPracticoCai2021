using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAI2021
{
    class TipoServicio
    {
        public int TipoServicioID { get; set; }
        public string PrioridadServicio { get; set; }
        public string EntregaPaquete { get; set; }
        public string RetiroPaquete { get; set; }

        public string elegirTipoServicio()
        {
            return "test elegirTipoServicio";
        }
    }
}
