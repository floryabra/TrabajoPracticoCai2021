using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCAI2021.data;

namespace TPCAI2021
{
    class Cliente
    {
        public int ClienteID{ get; set; }
        public int NroClienteCorporativo { get; set; }
        public decimal Saldo { get; set; }
        public string Facturacion { get; set; }
        public string ListaPersonalAutorizado { get; set; }

        public static Cliente buscarCliente(int nroCliente)
        {
            var ctx = new TPContext();
            var cliente = ctx.Clientes
                    .Where(s => s.NroClienteCorporativo == nroCliente)
                    .FirstOrDefault<Cliente>();
            return cliente;
        }

        public static Cliente mostrarEstadoCuenta(int idCliente)
        {
            var ctx = new TPContext();
            var cliente = ctx.Clientes.Find(idCliente);
            Console.WriteLine("-----------------------");
            Console.WriteLine("- Datos de la cuenta: -");
            Console.WriteLine("-----------------------");
            Console.WriteLine(
                "ID: " + cliente.ClienteID +
                " | Saldo: " + cliente.Saldo +
                " | Facturación: " + cliente.Facturacion);

            Console.WriteLine("-------------");

            return cliente;
        }

        public static void listarOrdenesDelCliente(int idCliente)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("- Ordenes de servicio del cliente: -");
            Console.WriteLine("------------------------------------");
            var ctx = new TPContext();
            var ordenes = ctx.OrdenesServicio
                    .Where(s => s.Cliente.ClienteID == idCliente)
                    .ToList();

            foreach (OrdenServicio o in ordenes)
            {
                OrdenServicio.mostrarOrden(o.OrdenServicioID);
            }
            Console.WriteLine("-------------");
        }

        public static void actualizarSaldoCuenta(int idCliente, double tarifa)
        {
            decimal tarifaAgregada = (decimal)tarifa;

            var ctx = new TPContext();
            var cliente = ctx.Clientes.Find(idCliente);
            cliente.Saldo += tarifaAgregada;
            ctx.SaveChanges();
        }

    }
}
