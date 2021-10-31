using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAI2021
{
    class OrdenServicio
    {
        public int nroOrdenServicio;
        public TipoServicio tipoServicio;
        public Paquete paquete;
        public string estadoOrden;
        public Direccion direccionOrigen;
        public Direccion direccionDestino;
        public decimal tarifa;
        public int dniAutorizadoDespacho;

        public OrdenServicio(int nroOrdenServicio, TipoServicio tipoServicio, Paquete paquete, string estadoOrden, Direccion direccionOrigen, Direccion direccionDestino, decimal tarifa, int dniAutorizadoDespacho)
        {
            this.nroOrdenServicio = nroOrdenServicio;
            this.tipoServicio = tipoServicio;
            this.paquete = paquete;
            this.estadoOrden = estadoOrden;
            this.direccionOrigen = direccionOrigen;
            this.direccionDestino = direccionDestino;
            this.tarifa = tarifa;
            this.dniAutorizadoDespacho = dniAutorizadoDespacho;
        }

        public string realizarOrdenServicio()
        {
            return "test realizarOrdenServicio";
        }

        public string conocerEstadoOrdenServicio()
        {
            return "test conocerEstadoOrdenServicio";
        }

        public string validarNumeroOrden()
        {
            return "test validarNumeroOrden";
        }

        public string mostrarOrden()
        {
            return "test mostrarOrden";
        }

        public string aprobarOrden()
        {
            return "test aprobarOrden";
        }
    }
}
