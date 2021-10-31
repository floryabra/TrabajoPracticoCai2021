using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAI2021
{
    class Cliente
    {
        public int nroClienteCorporativo;
        public CuentaCorriente cuenta;
        public string listaPersonalAutorizado;

        public Cliente(int nroClienteCorporativo, CuentaCorriente cuenta, string listaPersonalAutorizado)
        {
            this.nroClienteCorporativo = nroClienteCorporativo;
            this.cuenta = cuenta;
            this.listaPersonalAutorizado = listaPersonalAutorizado;
        }

        public string buscarCliente()
        {
            return "test buscarCliente";
        }

        public string ingresarCliente()
        {
            return "test ingresarCliente";
        }

    }
}
