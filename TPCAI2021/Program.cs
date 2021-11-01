using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAI2021
{
    class Program
    {
        static void Main(string[] args)
        {
            int idClienteCorporativo = IngresarClienteCorporativo();
            if(idClienteCorporativo != -1) 
            {
                MostrarMenuClienteCorporativo(idClienteCorporativo);
            }
            var cuenta = new CuentaCorriente(123, 123, (decimal)10.0, "test");
            var cliente = new Cliente(123, cuenta, "test");
            Console.WriteLine("Se creó un cliente por defecto con el nro de cuenta: " + cliente.nroClienteCorporativo);
            Console.ReadLine();
        }

        static void IngresarClienteCorporativo() {
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
            // Aprobar orden de servicio y guardar
        }

        static void ConsultarEstadoOrdenDeServicio(int idClienteCorporativo) {
            // pedir id orden de servicio y mostrar el status
            // OrdenServicio::conocerEstadoOrdenServicio
        }

        static void ConsultarEstadoDeCuenta(int idClienteCorporativo) {
            // mostrar status de cuenta cte.
            // CuentaCorriente::conocerEstadoCuentaCorriente();
        }
    }
}
