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
        public int Altura { get; set; }
        public int CodigoPostal { get; set; }
        public string Piso { get; set; }
        public Localidad Localidad { get; set; }

        public static Direccion ingresarDireccion(int idLocalidad, bool alcance = true)
        {
            var ctx = new TPContext();
            
          
            Console.WriteLine("Ingrese el nombre de la calle:");
            string calle;

            while (true)
            {
                calle = Console.ReadLine();
                if (calle != "") { break; } else { Console.WriteLine("Debe ingresar la calle"); }
            }


            Console.WriteLine("Ingrese la altura:");
            int altura;
            
            while (true)
            {
                bool alturaValida = int.TryParse(Console.ReadLine(), out altura);
                if (alturaValida) {
                    if (altura < 0)
                    {
                        Console.WriteLine("Debe ingresar un numero mayor a 0");
                    } else
                    {
                        break;
                    }
                    
                } else { 
                    Console.WriteLine("Debe ingresar un número entero"); 
                }
            }
            
            Console.WriteLine("Ingrese el Código Postal:");
            
            int codigoPostal;
            while (true)
            {
                bool cpValido = int.TryParse(Console.ReadLine(), out codigoPostal);

                if (cpValido && codigoPostal.ToString().Length <= 4)
                {
                    break;
                } else if (!cpValido) { 
                    Console.WriteLine("Debe ingresar un número entero");
                }
                else if (codigoPostal.ToString().Length > 4) { 
                    Console.WriteLine("Debe tener 4 dígitos como máximo");
                }
                else if (codigoPostal < 0)
                {
                    Console.WriteLine("Debe ingresar un numero mayor a 0");
                }

            }

            Console.WriteLine("Ingrese Piso y letra del departamento(En caso de que no corresponda, déjelo nulo):");
            string piso = Console.ReadLine();

            Localidad localidad = ctx.Localidades.Find(idLocalidad);

            var direccion = new Direccion() { AlcanceNacional = alcance, Calle = calle, Altura = altura, CodigoPostal = codigoPostal, Piso = piso, Localidad = localidad };
            ctx.Direcciones.Add(direccion);
            ctx.SaveChanges();
            return direccion;
        }
    }
}
