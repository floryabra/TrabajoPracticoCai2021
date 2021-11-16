using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCAI2021.data;

namespace TPCAI2021
{
    [Table("Direcciones")]
    class Direccion
    {
        public int DireccionId { get; set; }
        public bool AlcanceNacional { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public int CodigoPostal { get; set; }
        public string? Piso { get; set; }
       // public string Depto { get; set; }
        public Localidad Localidad { get; set; }

        public static Direccion ingresarDireccion(int idLocalidad, bool alcance = true)
        {
            var ctx = new TPContext();

            Console.WriteLine("Ingrese el nombre de la calle:");
            string calle = Console.ReadLine();
            Console.WriteLine("Ingrese la altura:"); //Validar que sean numeros
            string altura = Console.ReadLine();
            Console.WriteLine("Ingrese el Código Postal:");
            int codigoPostal = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese Piso y letra del departamento(En caso de que no corresponda, déjelo nulo):");
            string piso = Console.ReadLine(); //En el mismo string va a agregar piso y depto
           // Console.WriteLine("Ingrese el departamento, si corresponde:");
           // string depto = Console.ReadLine();

            Localidad localidad = ctx.Localidades.Find(idLocalidad);

            var direccion = new Direccion() { AlcanceNacional = alcance, Calle = calle, Altura = altura, CodigoPostal = codigoPostal, Piso = piso,/* Depto = depto,*/ Localidad = localidad };
            ctx.Direcciones.Add(direccion);
            ctx.SaveChanges();
            return direccion;
        }
    }
}
