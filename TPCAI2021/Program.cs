using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAI2021
{
    class Program
    {
        static void Main(string[] args)
        {
            bool mostrarMenu = true;
            while (mostrarMenu)
            {
                mostrarMenu = MenuPrincipal();
            }

        }

        private static bool MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1) Realizar solicitud de servicio");
            Console.WriteLine("2) Consultar estado de servicio");
            Console.WriteLine("3) Consultar estado de cuenta");
            Console.WriteLine("4) Ingresar cliente corporativo");
            Console.WriteLine("5) Salir");

            switch (Console.ReadLine())
            {
                case "1":
                    OrdenServicio.realizarOrdenServicio();
                    return true;
                case "2":
                    return true;
                case "3":
                    return true;
                case "4":
                    return true;
                case "5":
                    return false;
                default:
                    Console.WriteLine("Opción inválida");
                    return true;
            }
        }

        /*static void IngresarClienteCorporativo() {
            // ingresar y validar cliente corpo
            // return true si esta ok
            return -1;
        }

        static void MostrarMenuClienteCorporativo(int idClienteCorporativo) {
            // Mostrar las opciones de menu y llamar a la función de la option elegida
            switch (variableOpcionDeMenu)
            {
                case 1:
                    RealizarSolicitudDeServicio(idClienteCorporativo);
                break;

                case 2:
                    ConsultarEstadoOrdenDeServicio(idClienteCorporativo);
                break;

                case 3:
                    ConsultarEstadoDeCuenta(idClienteCorporativo);
                break;

                default:
            }
        }
        
        static void RealizarSolicitudDeServicio(int idClienteCorporativo) {
            // Pedir, validar datos y armar tarifa
            // Para id de servicio/paquete validar contra el ultimo agregado a una lista/archivo
            // Armar tipo de servicio: Crear nuevo objeto de TipoServicio (interface entrega, retiro: puerta o sucursal(si es puerta se crean los objetos dirección), prioridad)
            // Class paquete (Peso, tipo paquete)
            // Armar tarifa
            // Aprobar orden de servicio y guardar
        }

        static void ConsultarEstadoOrdenDeServicio(int idClienteCorporativo) {
            // pedir id orden de servicio y mostrar el status
            // OrdenServicio::conocerEstadoOrdenServicio
        }

        static void ConsultarEstadoDeCuenta(int idClienteCorporativo) {
            // mostrar status de cuenta cte.
            // CuentaCorriente::conocerEstadoCuentaCorriente();
        }*/

        
    }
}
