using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAI2021
{
    class Paquete
    {
        public int PaqueteId { get; set; }
        public decimal Peso { get; set; }
        public string TipoPaquete { get; set; }

        public static void ingresarPaquete()
        {
            Console.WriteLine("Ingrese el peso del paquete:");
            int peso = int.Parse(Console.ReadLine());
            // TODO: Permitir el ingreso en g/Kg
            if (peso > 30)
            {
                Console.WriteLine("El paquete excede el máximo permitido");
            }
            Console.WriteLine("Ingrese el tipo de paquete:");
            Console.WriteLine("1) Encomienda");
            Console.WriteLine("2) Sobre");
            string tipoPaquete = Console.ReadLine();

            // TODO: Bucle de carga

        }
    }
}
