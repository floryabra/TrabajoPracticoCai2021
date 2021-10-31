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


            var cuenta = new CuentaCorriente(123, 123, (decimal)10.0, "test");
            var cliente = new Cliente(123, cuenta, "test");
            Console.WriteLine("Se creó un cliente por defecto con el nro de cuenta: " + cliente.nroClienteCorporativo);
            Console.ReadLine();
        }
    }
}
