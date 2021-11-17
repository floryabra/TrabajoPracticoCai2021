using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCAI2021.data;

namespace TPCAI2021
{
    class Program
    {
        static void Main(string[] args)
        {

            int idCliente = 0;

            while (true)
            {
                Console.WriteLine("Ingrese su nro de cliente");
                int loginCliente = int.Parse(Console.ReadLine());
                Cliente cliente = Cliente.buscarCliente(loginCliente);

                if (cliente == null)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("- El Nro de cliente no es válido -");
                    Console.WriteLine("----------------------------------");
                } else
                {
                    idCliente = cliente.ClienteID;
                    break;
                }
                
            }

            List<string> menuItems = new List<string>()
            {
                "Realizar solicitud de servicio",
                "Consultar estado de la orden de servicio",
                "Consultar estado de cuenta corriente",
                "Gestionar db"
            };


            while (true)
            {
                string opcionSeleccionada = mostrarMenu(menuItems);

                if (opcionSeleccionada == "Realizar solicitud de servicio")
                {
                    OrdenServicio.realizarOrdenServicio(idCliente);
                }
                else if (opcionSeleccionada == "Consultar estado de la orden de servicio")
                {
                    Console.WriteLine("Ingrese la orden a consultar:");
                    //Cliente.listarOrdenesDelCliente(idCliente);
                    int idOrden = int.Parse(Console.ReadLine());
                    string ordenValida = OrdenServicio.validarNumeroOrden(idOrden);

                    if (ordenValida != "ok")
                    {
                        Console.WriteLine(ordenValida);
                    } else
                    {
                        OrdenServicio.mostrarOrden(idOrden);
                    }
                    
                }
                else if (opcionSeleccionada == "Consultar estado de cuenta corriente")
                {
                    Cliente.mostrarEstadoCuenta(idCliente);
                }
                else if (opcionSeleccionada == "Gestionar db")
                {
                    gestionarDatos();
                }
                else if (opcionSeleccionada == "Finalizar")
                {
                    Environment.Exit(0);
                }
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }

        }

        public static string mostrarMenu(List<string> items, string titulo = "Seleccione una opción:")
        {

            Console.Clear();
            Console.WriteLine(titulo);
            Console.WriteLine("--------");
            int indiceMenu = 1;
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(indiceMenu + ") " + items[i]);
                indiceMenu++;
            }

            Console.WriteLine(indiceMenu + ") Finalizar");
            Console.WriteLine("--------");
            string indiceOpcionSeleccionadaMenu = Console.ReadLine();
            if (int.TryParse(indiceOpcionSeleccionadaMenu, out int opcionSeleccionada))
            {
                if (opcionSeleccionada <= items.Count) {
                    return items[opcionSeleccionada - 1].Trim();
                } else
                {
                    return "Finalizar";
                }
                
            } else
            {
                Console.WriteLine("Opcion inválida");
                return "Finalizar";
            }
        }

        static void gestionarDatos()
        {
            List<string> menuItems = new List<string>()
            {
                "Sucursales",
                "Clientes"
            };

            while (true)
            {
                string opcionSeleccionada = mostrarMenu(menuItems, "Seleccione los datos a gestionar");

                if (opcionSeleccionada == "Sucursales")
                {
                    Sucursal.menuABM();
                }
                else if (opcionSeleccionada == "Clientes")
                {
                    Cliente.menuABM();
                }
                else if (opcionSeleccionada == "Finalizar")
                {
                    break;
                }
                Console.ReadLine();
            }
        }
    }
}
