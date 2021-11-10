using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCAI2021.data;

namespace TPCAI2021
{
    class OrdenServicio
    {
        public int OrdenServicioID { get; set; }
        public TipoServicio TipoServicio { get; set; }
        public ICollection<Paquete> Paquetes { get; set; }
        public string EstadoOrden { get; set; }
        public Direccion DireccionOrigen { get; set; }
        public Direccion DireccionDestino { get; set; }
        public decimal Tarifa { get; set; }
        public int DniAutorizadoDespacho { get; set; }
        
        public static void realizarOrdenServicio(int idCliente)
        {
            int idLocalidadOrigen = 0;
            int idLocalidadDestino = 0;

            int idProvinciaOrigen = 0;
            int idProvinciaDestino = 0;
            Provincia provinciaOrigen = null;
            Provincia provinciaDestino = null;

            Console.Clear();
            Console.WriteLine("Nueva orden de servicio");

            // 1 - Selección de la provincia de origen

            Console.WriteLine("-----------");
            Console.WriteLine("Seleccione la provincia de origen:");
            Provincia.listarProvincias();

            idProvinciaOrigen = int.Parse(Console.ReadLine());
            provinciaOrigen = Provincia.getProvincia(idProvinciaOrigen);


            // 2 - Selección de sucursal o domicilio de origen
            Console.WriteLine("¿Desea enviar el paquete desde su domicilio o desde una sucursal?");
            Console.WriteLine("1) Sucursal");
            Console.WriteLine("2) Domicilio");
            string origenEnvio = Console.ReadLine();

            Console.WriteLine("Seleccione la localidad de origen:");
            Localidad.listarLocalidades(idProvinciaOrigen);
            idLocalidadOrigen = int.Parse(Console.ReadLine());
            Localidad localidadOrigen = Localidad.getLocalidad(idLocalidadOrigen);

            if (origenEnvio == "1")
            {
                Console.WriteLine("Seleccione la sucursal de origen:");
                Sucursal.listarSucursales(idLocalidadOrigen);

                int idSucursalOrigen = int.Parse(Console.ReadLine());
                Sucursal sucursalOrigen = Sucursal.getSucursal(idSucursalOrigen);
            }
            else if (origenEnvio == "2")
            {
                Direccion direccionOrigen = Direccion.ingresarDireccion(idLocalidad: idLocalidadOrigen);
            }

            // 3 - Destino nacional o internacional
            Console.WriteLine("¿El destino es nacional?");
            Console.WriteLine("1) Si");
            Console.WriteLine("2) No");
            string destinoNacional = Console.ReadLine();
            
            if (destinoNacional == "1")
            {

                Console.WriteLine("Seleccione la provincia de destino:");
                Provincia.listarProvincias();

                idProvinciaDestino = int.Parse(Console.ReadLine());
                provinciaDestino = Provincia.getProvincia(idProvinciaDestino);

                Console.WriteLine("Seleccione la localidad de destino:");
                Localidad.listarLocalidades(idProvinciaDestino);
                idLocalidadDestino = int.Parse(Console.ReadLine());
                Localidad localidadDestino = Localidad.getLocalidad(idLocalidadDestino);

            }
            else if (destinoNacional == "2")
            {
                Console.WriteLine("Seleccione la región de destino");
                Console.WriteLine("1) Países limítrofes");
                Console.WriteLine("2) Resto de América Latina");
                Console.WriteLine("3) América del Norte");
                Console.WriteLine("4) Europa");
                Console.WriteLine("5) Asia");

                int regionDestino = int.Parse(Console.ReadLine());
                Console.WriteLine("Seleccione el pais de destino:");
                Pais.listarPaises(regionDestino);
                int idPaisDestino = int.Parse(Console.ReadLine());
                Pais paisDestino = Pais.getPais(idPaisDestino);
            }

            // 4 - Entrega en sucursal o particular
            Console.WriteLine("¿La entrega es en sucursal o domicilio?");
            Console.WriteLine("1) Sucursal");
            Console.WriteLine("2) Domicilio");
            string tipoEntrega = Console.ReadLine();
            if (tipoEntrega == "1")
            {

                Console.WriteLine("Seleccione la sucursal de destino:");
                Sucursal.listarSucursales(idLocalidadDestino);

                int idSucursalDestino = int.Parse(Console.ReadLine());
                Sucursal sucursalDestino = Sucursal.getSucursal(idSucursalDestino);

            }
            else if (tipoEntrega == "2")
            {
                if (destinoNacional == "2")
                {
                    Direccion direccionDestino = Direccion.ingresarDireccion(alcance: false, idLocalidad: idLocalidadDestino);
                } else
                {
                    Direccion direccionDestino = Direccion.ingresarDireccion(idLocalidad: idLocalidadDestino);
                }
                
            }

            // 5 - Entrega urgente
            Console.WriteLine("¿Es entrega urgente?");
            Console.WriteLine("1) Si (recargo del 10% con tope a $500 en el precio fina)");
            Console.WriteLine("2) No");
            string urgencia = Console.ReadLine();

            // 6 - Detalles del paquete
            List<Paquete> paquetes = new List<Paquete>();
            while (true)
            {
                paquetes.Add(Paquete.ingresarPaquete());
                Console.WriteLine("¿Desea agrgar otro paquete?");
                Console.WriteLine("1) Si");
                Console.WriteLine("2) No");
                if (Console.ReadLine() == "2")
                {
                    break;
                }
            }

            // 7 - Cálculo de tarifa
            double tarifa = 0;
            int[,] arrayTarifas = new int[,] { { 50, 100, 150, 200, 250 }, { 100, 150, 200, 250, 300 }, { 150, 200, 250, 300, 350 }, { 200, 250, 300, 350, 400 } };
            int alcanceEntrega;
            int categoriaPaquete;

            if (idLocalidadOrigen == idLocalidadDestino)
            {
                alcanceEntrega = 0;
            } 
            else if (idProvinciaOrigen == idProvinciaDestino)
            {
                alcanceEntrega = 1;
            } else if (destinoNacional == "2")
            {
                alcanceEntrega = 4;
            }
            else if (provinciaOrigen.IdRegion == provinciaDestino.IdRegion)
            {
                alcanceEntrega = 2;
            } else 
            {
                alcanceEntrega = 3;
            }

            foreach(Paquete p in paquetes)
            {
                if (p.Peso < decimal.Parse("0.5"))
                {
                    categoriaPaquete = 0;
                } else if  (p.Peso < 10)
                {
                    categoriaPaquete = 1;
                }
                else if (p.Peso < 20)
                {
                    categoriaPaquete = 2;
                }
                else
                {
                    categoriaPaquete = 3;
                }

                tarifa += arrayTarifas[categoriaPaquete, alcanceEntrega];
            }

            if (urgencia == "1")
            {
                double recargo = tarifa * 0.1;
                if (recargo > 500)
                {
                    recargo = 500;
                }

                tarifa += recargo;
            }

            Console.WriteLine("El costo del servicio es de $" + tarifa);

            // 8 - Confirmar servicio
            Console.WriteLine("¿Desea confirmar el servicio?");
            Console.WriteLine("1) Si");
            Console.WriteLine("2) No");
            if (Console.ReadLine() == "2")
            {
                return;
            }

            // 9 - Agregar DNI autorizado a despachar
            Console.WriteLine("¿Desea agregar el DNI del autorizado a despachar?");
            Console.WriteLine("1) Si");
            Console.WriteLine("2) No");
            if (Console.ReadLine() == "1")
            {
                while (true)
                {
                    Console.WriteLine("Ingrese el DNI:");
                    string dniAutorizado = Console.ReadLine();

                    Console.WriteLine("¿Desea agrgar otro dni?");
                    Console.WriteLine("1) Si");
                    Console.WriteLine("2) No");
                    if (Console.ReadLine() == "2")
                    {
                        break;
                    }
                }
            }

            aprobarOrden();

        }

        public string conocerEstadoOrdenServicio()
        {
            return "test conocerEstadoOrdenServicio";
        }

        public string validarNumeroOrden()
        {
            return "test validarNumeroOrden";
        }

        public string mostrarOrden()
        {
            return "test mostrarOrden";
        }

        public static void aprobarOrden()
        {
            var ctx = new TPContext();

            var ordenServicio = new OrdenServicio() {  }; // TO DO
            ctx.OrdenesServicio.Add(ordenServicio);
            ctx.SaveChanges();
            Console.WriteLine("Orden de servicio generada");
        }
    }
}
