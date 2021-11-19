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

        public static void ingresarCliente()
        {
            var ctx = new TPContext();
            Console.WriteLine("Ingrese el nro del nuevo cliente:");
            int nroCliente = int.Parse(Console.ReadLine());
            // Valida entero "Ingrese un número entero"
            // Valida que el cliente sea corpo "El número ingresado no se corresponde con un cliente coorporativo"

            var cliente = new Cliente() { NroClienteCorporativo = nroCliente };
            ctx.Clientes.Add(cliente);
            ctx.SaveChanges();
            Console.WriteLine("Cliente agregado.");
        }

        public static void eliminarCliente()
        {
            var ctx = new TPContext();

            Console.WriteLine("Ingrese el nro de cliente a eliminar");

            int idCliente= int.Parse(Console.ReadLine());
            Cliente cliente = ctx.Clientes.Find(idCliente);

            ctx.Clientes.Remove(cliente);
            ctx.SaveChanges();

            Console.WriteLine("Cliente eliminado");
        }

        public static void listarClientes()
        {
            var ctx = new TPContext();
            var clientes = ctx.Clientes.ToList();

            Console.WriteLine("id | Nro cliente corporativo");
            foreach (Cliente c in clientes)
            {
                Console.WriteLine(c.ClienteID + "|" + c.NroClienteCorporativo);
            }
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

            /*
            Console.WriteLine("Lista del personal autorizado a despachar:");

            string[] personas = cliente.ListaPersonalAutorizado.Split(',');

            foreach (var p in personas)
            {
                Console.WriteLine("DNI: " + p.Trim());
            }*/

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

        public static void menuABM()
        {
            List<string> menuItems = new List<string>()
            {
                "Agregar cliente",
                "Eliminar cliente",
                "Listar clientes"
            };

            while (true)
            {

                string opcionSeleccionada = Program.mostrarMenu(menuItems);

                if (opcionSeleccionada == "Agregar cliente")
                {
                    ingresarCliente();
                }
                else if (opcionSeleccionada == "Eliminar cliente")
                {
                    eliminarCliente();
                }
                else if (opcionSeleccionada == "Listar clientes")
                {
                    listarClientes();
                }
                else if (opcionSeleccionada == "Salir")
                {
                    break;
                }
                Console.ReadKey();
            }
        }

    }
}
