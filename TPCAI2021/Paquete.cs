﻿using System;
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
        public decimal Peso { get; set; }
        public string TipoPaquete { get; set; }

        public static void ingresarPaquete()
        {
            string tipoPaquete = "Sobre";
            Console.WriteLine("Ingrese el peso del paquete (en kg):");
            decimal peso = decimal.Parse(Console.ReadLine());
            
            if (peso > decimal.Parse("30.0"))
            {
                Console.WriteLine("El paquete excede el máximo permitido");
            }

            if (peso > decimal.Parse("0.5"))
            {
                tipoPaquete = "Encomienda";
            }

            var ctx = new TPContext();

            var paquete = new Paquete() { Peso = peso, TipoPaquete = tipoPaquete};
            ctx.Paquetes.Add(paquete);
            ctx.SaveChanges();
            Console.WriteLine("Paquete agregado");
        }
    }
}
