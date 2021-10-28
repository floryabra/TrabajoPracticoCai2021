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
            Console.WriteLine("Holis");

            var cliente = new Cliente("Juan");
            Console.WriteLine("Se creó un cliente por defecto con el nombre de " + cliente.Nombre);
            Console.ReadLine();
        }
    }
}
