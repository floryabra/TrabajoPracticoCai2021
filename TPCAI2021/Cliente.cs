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
        public string Nombre { get; set; }
        //public CuentaCorriente cuenta { get; set; }
        public int NroCuentaCorriente { get; set; }
        public decimal Saldo { get; set; }
        public string Facturacion { get; set; }

        public string ListaPersonalAutorizado { get; set; }

        public static void buscarCliente(int idCliente)
        {
            var ctx = new TPContext();
            var clientes = ctx.Clientes.Find(idCliente);
            Console.WriteLine(clientes.ClienteID + "|" + clientes.Nombre);
        }

        public static void ingresarCliente()
        {
            var ctx = new TPContext();
            Console.WriteLine("Ingrese el nombre del nuevo cliente:");
            string nombreCliente = Console.ReadLine();

            var cliente = new Cliente() { Nombre = nombreCliente };
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

            Console.WriteLine("id | Nombre");
            foreach (Cliente c in clientes)
            {
                Console.WriteLine(c.ClienteID + "|" + c.Nombre);
            }
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
