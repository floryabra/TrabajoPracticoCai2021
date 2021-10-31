using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAI2021
{
    class CuentaCorriente
    {
        public int nroClienteCorporativo;
        public int nroCuentaCorriente;
        public decimal saldo;
        public string facturacion;

        public CuentaCorriente(int nroClienteCorporativo, int nroCuentaCorriente, decimal saldo, string facturacion)
        {
            this.nroClienteCorporativo = nroClienteCorporativo;
            this.nroCuentaCorriente = nroCuentaCorriente;
            this.saldo = saldo;
            this.facturacion = facturacion;
        }

        //public List<ServiciosCumplidosPendientesDeFacturacion>;

        public string conocerEstadoCuentaCorriente()
        {

            return "test conocerEstadoCuentaCorriente";

        }

    }
}
