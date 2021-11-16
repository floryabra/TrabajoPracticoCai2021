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
        public double Tarifa { get; set; }
        public int DniAutorizadoDespacho { get; set; }
        public Direccion DireccionOrigen { get; set; }
        public Direccion DireccionDestino { get; set; }
        public Sucursal SucursalOrigen { get; set; }
        public Sucursal SucursalDestino { get; set; }

        public static void realizarOrdenServicio(int idCliente)
        {
            int idLocalidadOrigen = 0;
            int idLocalidadDestino = 0;

            int idProvinciaOrigen = 0;
            int idProvinciaDestino = 0;
            Provincia provinciaOrigen = null;
            Provincia provinciaDestino = null;

            Direccion direccionOrigen = null;
            Direccion direccionDestino = null;

            Sucursal sucursalOrigen = null;
            Sucursal sucursalDestino = null;

            int idPaisDestino = 0;

            Console.Clear();
            Console.WriteLine("Nueva orden de servicio");

            // 1 - Selección de la provincia de origen
            Console.WriteLine("Información correspondiente a la dirección de origen:");
            Console.WriteLine("Seleccione la provincia de origen:");
            Provincia.listarProvincias();

            idProvinciaOrigen = int.Parse(Console.ReadLine());
            provinciaOrigen = Provincia.getProvincia(idProvinciaOrigen);
//Primero localidad y despues tipo de servicio
            Console.WriteLine("");
            Console.WriteLine("Seleccione la localidad de origen:");
            Localidad.listarLocalidades(idProvinciaOrigen);
            idLocalidadOrigen = int.Parse(Console.ReadLine());
            Localidad localidadOrigen = Localidad.getLocalidad(idLocalidadOrigen);
            
            // 2 - Selección de sucursal o domicilio de origen
            Console.WriteLine("***********");
            Console.WriteLine("El retiro del paquete será:");
            Console.WriteLine("1) En Sucursal");
            Console.WriteLine("2) En puerta");
            Console.WriteLine("");
            string origenEnvio = Console.ReadLine();

            

            if (origenEnvio == "1")
            {
                Console.WriteLine("");
                Console.WriteLine("Seleccione la sucursal de origen:");
                Sucursal.listarSucursales(idLocalidadOrigen);

                int idSucursalOrigen = int.Parse(Console.ReadLine());
                sucursalOrigen = Sucursal.getSucursal(idSucursalOrigen);
            }
            else if (origenEnvio == "2")
            {
                direccionOrigen = Direccion.ingresarDireccion(idLocalidad: idLocalidadOrigen);
            }

            // 3 - Destino nacional o internacional
            Console.WriteLine("***********");
            Console.WriteLine("El envío del paquete será: ");
            Console.WriteLine("1) Nacional");
            Console.WriteLine("2) Internacional");
            Console.WriteLine("");
            string destinoNacional = Console.ReadLine();
            
            if (destinoNacional == "1")
            {

                Console.WriteLine("");
                Console.WriteLine("Seleccione la provincia de destino:");
                Provincia.listarProvincias();

                idProvinciaDestino = int.Parse(Console.ReadLine());
                provinciaDestino = Provincia.getProvincia(idProvinciaDestino);

                Console.WriteLine("");
                Console.WriteLine("Seleccione la localidad de destino:");
                Localidad.listarLocalidades(idProvinciaDestino);
                idLocalidadDestino = int.Parse(Console.ReadLine());
                Localidad localidadDestino = Localidad.getLocalidad(idLocalidadDestino);

            } //ESTO NO IRIA, LE PIDO EL PAIS E INFIERO LA REGION
            else if (destinoNacional == "2")
            {
                Console.WriteLine("");
                Console.WriteLine("Seleccione la región de destino");
                Console.WriteLine("1) Países limítrofes");
                Console.WriteLine("2) Resto de América Latina");
                Console.WriteLine("3) América del Norte");
                Console.WriteLine("4) Europa");
                Console.WriteLine("5) Asia");
                Console.WriteLine("");

                int regionDestino = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                Console.WriteLine("Seleccione el pais de destino:");
                Pais.listarPaises(regionDestino);
                idPaisDestino = int.Parse(Console.ReadLine());
                Pais paisDestino = Pais.getPais(idPaisDestino);
            }

            // 4 - Entrega en sucursal o particular
            Console.WriteLine("***********");
            Console.WriteLine("La entrega del paquete será:");
            Console.WriteLine("1) En Sucursal");
            Console.WriteLine("2) En Puerta");
            Console.WriteLine("");
            string tipoEntrega = Console.ReadLine();
            if (tipoEntrega == "1")
            {

                Console.WriteLine("Seleccione la sucursal de destino:");
                if (destinoNacional == "1")
                {
                    Sucursal.listarSucursales(idLocalidadDestino);
                } else if (destinoNacional == "2")
                {
                    Sucursal.listarSucursales(0, idPaisDestino);
                }
                

                int idSucursalDestino = int.Parse(Console.ReadLine());
                sucursalDestino = Sucursal.getSucursal(idSucursalDestino);

            }
            else if (tipoEntrega == "2")
            {
                if (destinoNacional == "2")
                {
                    direccionDestino = Direccion.ingresarDireccion(alcance: false, idLocalidad: idLocalidadDestino);
                } else
                {
                    direccionDestino = Direccion.ingresarDireccion(idLocalidad: idLocalidadDestino);
                }
                
            }

            // 5 - Entrega urgente
            Console.WriteLine("***********");
            Console.WriteLine("¿El tipo de servicio que desea realizar, es urgente?  (Se entrega en 48hs, recargo del 10%). Ingrese S o N.");
            Console.WriteLine("");
            string urgencia = Console.ReadLine();

            // 6 - Detalles del paquete
            Console.WriteLine("***********");
            List<Paquete> paquetes = new List<Paquete>();
            while (true)
            {
                paquetes.Add(Paquete.ingresarPaquete());
                Console.WriteLine("¿Desea agregar otro paquete? S/N"); //INGRESAR S O N, NO 1 O 2
                Console.WriteLine("1) Si");
                Console.WriteLine("2) No");
                if (Console.ReadLine() == "2")
                {
                    break;
                }
            }

            // 7 - Cálculo de tarifa
            Console.WriteLine("***********");
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

            if (urgencia.ToLower() == "s")
            {
                double recargo = tarifa * 0.1;
                if (recargo > 500)
                {
                    recargo = 500;
                }

                tarifa += recargo;
            }

            Console.WriteLine("Tarifa:" + tarifa);

            // 8 - Confirmar servicio
            Console.WriteLine("***********");
            Console.WriteLine("¿Desea confirmar el servicio? S/N");
            if (Console.ReadLine().ToLower() == "n")
            {
                return;
            }

            // 9 - Agregar DNI autorizado a despachar
            Console.WriteLine("***********");
            Console.WriteLine("¿Desea ingresar el DNI de un autorizado a despachar el servicio? S/N");
            int dniAutorizadoDespacho = 0;
            
            if (Console.ReadLine().ToLower() == "s")
            {
                while (true)
                {
                    Console.WriteLine("Ingrese el DNI del autorizado a despachar:");
                    dniAutorizadoDespacho = int.Parse(Console.ReadLine());

                    var ctx = new TPContext();
                    var cliente = ctx.Clientes.Find(idCliente);
                    bool dniExisteEnAutorizadosCliente = cliente.ListaPersonalAutorizado.Contains(dniAutorizadoDespacho);
                    if (dniExisteEnAutorizadosCliente)
                    {
                        break;
                    } else
                    {
                        Console.WriteLine("El DNI ingresado no se encuentra en la lista de autorizados por el cliente");
                    }
                }
                
            }

            TipoServicio tipoServicio = new TipoServicio();

            string estadoOrden = "Orden de servicio iniciada";

            aprobarOrden(tipoServicio, paquetes, tarifa, dniAutorizadoDespacho, direccionOrigen, direccionDestino, sucursalOrigen, sucursalDestino, estadoOrden);

        }

        public OrdenServicio conocerEstadoOrdenServicio(int idOrden)
        {
            var ctx = new TPContext();
            var ordenServicio = ctx.OrdenesServicio.Find(idOrden);
            Console.WriteLine(ordenServicio.EstadoOrden);
            return ordenServicio;
        }

        public string validarNumeroOrden(int idOrden)
        {
            var ctx = new TPContext();
            var ordenServicio = ctx.OrdenesServicio.Find(idOrden);
            if (ordenServicio == null)
            {
                return "El número de ingresado no se corresponde a una orden de servicio";
            } else
            {
                return "ok";
            }
        }

        public OrdenServicio mostrarOrden(int idOrden)
        {
            var ctx = new TPContext();
            var ordenServicio = ctx.OrdenesServicio.Find(idOrden);
            Console.WriteLine("Origen | Destino | Estado de Orden | Tarifa | Prioridad | Retiro | DNI autorizado");
            Console.WriteLine(
                ordenServicio.DireccionOrigen.Calle + ordenServicio.DireccionOrigen.Altura + ordenServicio.SucursalOrigen.Nombre + "|" + 
                ordenServicio.DireccionDestino.Calle + ordenServicio.DireccionDestino.Altura + ordenServicio.SucursalDestino.Nombre + "|" + 
                ordenServicio.EstadoOrden + "|" +
                ordenServicio.Tarifa + "|" +
                ordenServicio.TipoServicio.PrioridadServicio + "|" +
                ordenServicio.TipoServicio.RetiroPaquete + "|" +
                ordenServicio.DniAutorizadoDespacho
                );
            return ordenServicio;
        }

        public static void aprobarOrden(
            TipoServicio tipoServicio, 
            List<Paquete> paquetes, 
            double tarifa, 
            int dniAutorizadoDespacho,
            Direccion direccionOrigen,
            Direccion direccionDestino,
            Sucursal sucursalOrigen,
            Sucursal sucursalDestino,
            string estadoOrden = "Orden de servicio iniciada")
        {
            var ctx = new TPContext();
            var ordenServicio = new OrdenServicio() { 
                TipoServicio = tipoServicio, 
                Paquetes = paquetes,
                Tarifa = tarifa,
                DniAutorizadoDespacho = dniAutorizadoDespacho,
                DireccionOrigen = direccionOrigen,
                DireccionDestino = direccionDestino,
                SucursalOrigen = sucursalOrigen,
                SucursalDestino = sucursalDestino,
                EstadoOrden = estadoOrden,
            };
            ctx.OrdenesServicio.Add(ordenServicio);
            ctx.SaveChanges();
            Console.WriteLine("***********");
            Console.WriteLine("Orden de servicio generada");
            Console.WriteLine("***********");
        }
    }
}
