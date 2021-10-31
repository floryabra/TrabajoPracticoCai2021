using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAI2021
{
    class TipoServicio
    {
        public string prioridadServicio;
        public string entregaPaquete;
        public string retiroPaquete;

        public TipoServicio(string prioridadServicio, string entregaPaquete, string retiroPaquete)
        {
            this.prioridadServicio = prioridadServicio;
            this.entregaPaquete = entregaPaquete;
            this.retiroPaquete = retiroPaquete;
        }

        public string elegirTipoServicio()
        {
            return "test elegirTipoServicio";
        }
    }
}
