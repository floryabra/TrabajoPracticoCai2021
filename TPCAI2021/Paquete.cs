using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCAI2021.data;

namespace TPCAI2021
{
    class Paquete
    {
        public int PaqueteId { get; set; }
        public double Peso { get; set; }
        public string TipoPaquete { get; set; }

        public static Paquete ingresarPaquete()
        {
            string tipoPaquete = "Correspondencia";
            Console.WriteLine("Detalles del paquete a enviar: ");
            Console.WriteLine("Ingrese el peso del paquete (en kg):");
            double peso = double.Parse(Console.ReadLine());
            
            if (peso > double.Parse("30.0"))
            {
                Console.WriteLine("El paquete excede el máximo permitido (30kg)");
            }

            if (peso > double.Parse("0.5"))
            {
                tipoPaquete = "Encomienda";
            }

            var ctx = new TPContext();

            var paquete = new Paquete() { Peso = peso, TipoPaquete = tipoPaquete};
            ctx.Paquetes.Add(paquete);
            ctx.SaveChanges();
            Console.WriteLine("Se agregó un paquete del tipo: " + tipoPaquete);
            return paquete;
        }

        public Paquete mostrarPaquete(int idPaquete)
        {
            var ctx = new TPContext();
            var paquete = ctx.Paquetes.Find(idPaquete);
            Console.WriteLine("ID: " + paquete.PaqueteId + " | Tipo: " + paquete.TipoPaquete + " | Peso: " + paquete.Peso);
            return paquete;
        }
    }
}
