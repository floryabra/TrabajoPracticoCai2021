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
        public Cliente Cliente { get; set; }
        public string PrioridadServicio { get; set; }
        public string RetiroPaquete { get; set; } // Es cuando la empresa obtiene el paquete desde el origen
        public string EntregaPaquete { get; set; } // Es cuando la empresa entrega el paquete al destino final
        public ICollection<Paquete> Paquetes { get; set; }
        public string EstadoOrden { get; set; }
        public double TarifaFinal { get; set; }
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
            Pais paisDestino = null;

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
            Localidad.listarLocalidadesPorProvincia(idProvinciaOrigen);
            idLocalidadOrigen = int.Parse(Console.ReadLine());
            Localidad localidadOrigen = Localidad.getLocalidad(idLocalidadOrigen);
            
            // 2 - Selección de sucursal o domicilio de origen
            Console.WriteLine("***********");
            Console.WriteLine("El retiro del paquete será:");
            Console.WriteLine("1) En sucursal");
            Console.WriteLine("2) En puerta");
            Console.WriteLine("");
            string origenEnvio = Console.ReadLine();

            string retiroPaquete = "";
            if (origenEnvio == "1")
            {
                Console.WriteLine("");
                Console.WriteLine("Seleccione la sucursal de origen:");
                Sucursal.listarSucursales(idLocalidadOrigen);

                int idSucursalOrigen = int.Parse(Console.ReadLine());
                sucursalOrigen = Sucursal.getSucursal(idSucursalOrigen);
                retiroPaquete = "Sucursal";
            }
            else if (origenEnvio == "2")
            {
                direccionOrigen = Direccion.ingresarDireccion(idLocalidad: idLocalidadOrigen);
                retiroPaquete = "Domicilio";
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
                Localidad.listarLocalidadesPorProvincia(idProvinciaDestino);
                idLocalidadDestino = int.Parse(Console.ReadLine());
                Localidad localidadDestino = Localidad.getLocalidad(idLocalidadDestino);

            }
            else if (destinoNacional == "2")
            {
                Console.WriteLine("");
                Console.WriteLine("Seleccione el pais de destino:");
                Pais.listarPaises();
                idLocalidadDestino = 17; // En los envíos internacionales el paquete viaja a CABA.
                idProvinciaDestino = 6;
                idPaisDestino = int.Parse(Console.ReadLine());
                paisDestino = Pais.getPais(idPaisDestino);
            }

            // 4 - Entrega en sucursal o particular
            Console.WriteLine("***********");
            Console.WriteLine("La entrega del paquete será:");
            Console.WriteLine("1) En Sucursal");
            Console.WriteLine("2) En Puerta");
            Console.WriteLine("");
            string tipoEntrega = Console.ReadLine();
            string entregaPaquete = "";
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
                entregaPaquete = "Sucursal";

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

                if (direccionOrigen == direccionDestino)
                {
                    Console.WriteLine("La dirección de origen no puede ser igual a la dirección de destino");
                    return;
                }

                entregaPaquete = "Domicilio";

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
                if (Console.ReadLine().ToLower() == "n")
                {
                    break;
                }
            }

            // 7 - Cálculo de tarifa
            Console.WriteLine("***********");
            double tarifa = 0;

            foreach(Paquete p in paquetes)
            {

                Tarifa tarifario = Tarifa.obtenerTarifario(p.Peso);

                if (idLocalidadOrigen == idLocalidadDestino)
                {
                    tarifa = tarifario.Local;
                }
                else if (idProvinciaOrigen == idProvinciaDestino)
                {
                    tarifa = tarifario.Provincial;
                }
                else if (provinciaOrigen.IdRegion == provinciaDestino.IdRegion)
                {
                    tarifa = tarifario.Regional;
                }
                else
                {
                    tarifa = tarifario.Nacional;
                }

                if (destinoNacional == "2")
                {
                    if (paisDestino.RegionID == 1)
                    {
                        tarifa += tarifario.InternacionalLimitrofe;
                    }
                    else if (paisDestino.RegionID == 2)
                    {
                        tarifa += tarifario.InternacionalALatina;
                    }
                    else if (paisDestino.RegionID == 3)
                    {
                        tarifa += tarifario.InternacionalANorte;
                    }
                    else if (paisDestino.RegionID == 4)
                    {
                        tarifa += tarifario.InternacionalEuropa;
                    }
                    else
                    {
                        tarifa += tarifario.InternacionalAsia;
                    }
                }

                if (retiroPaquete == "Domicilio")
                {
                    tarifa += 50;
                }

                if (entregaPaquete == "Domicilio")
                {
                    tarifa += 50;
                }
            }

            string prioridadServicio = "No urgente";

            if (urgencia.ToLower() == "s")
            {
                double recargo = tarifa * 0.1;
                if (recargo > 500)
                {
                    recargo = 500;
                }

                tarifa += recargo;
                prioridadServicio = "Urgente";
            }

            Console.WriteLine("***********");

            Console.WriteLine("Se va a crear la siguiente orden de servicio:");
            Console.WriteLine("");
            Console.WriteLine("Prioridad:" + prioridadServicio + " | Tipo entrega: " + entregaPaquete + " | Tipo retiro: " + retiroPaquete);
            int indexPaquetes = 0;

            Console.WriteLine("Paquetes incluidos en la orden: ");
            Console.WriteLine("--------------------");
            foreach (Paquete p in paquetes)
            {
                Console.WriteLine(indexPaquetes.ToString() + "| Peso: " + p.Peso + " | Tipo: " + p.TipoPaquete);
            }

            Console.WriteLine("--------------------");

            Console.WriteLine("Tarifa:" + tarifa);

            // 8 - Confirmar servicio
            Console.WriteLine("*************************************");
            Console.WriteLine("* ¿Desea confirmar el servicio? S/N *");
            Console.WriteLine("*************************************");
            if (Console.ReadLine().ToLower() == "n")
            {
                return;
            }

            // 9 - Agregar DNI autorizado a despachar
            Console.WriteLine("***********");
            Console.WriteLine("¿Desea ingresar el DNI de un autorizado a despachar el servicio? S/N");
            int dniAutorizadoDespacho = 0;

            var ctx = new TPContext();
            var cliente = ctx.Clientes.Find(idCliente);

            if (Console.ReadLine().ToLower() == "s")
            {
                while (true)
                {
                    Console.WriteLine("Ingrese el DNI del autorizado a despachar:");
                    dniAutorizadoDespacho = int.Parse(Console.ReadLine());

                    bool dniExisteEnAutorizadosCliente = cliente.ListaPersonalAutorizado.Contains(dniAutorizadoDespacho.ToString());
                    if (dniExisteEnAutorizadosCliente)
                    {
                        break;
                    } else
                    {
                        Console.WriteLine("El DNI ingresado no se encuentra en la lista de autorizados por el cliente");
                    }
                }
                
            }

            string estadoOrden = "Orden de servicio iniciada";

            aprobarOrden(cliente, prioridadServicio, entregaPaquete, retiroPaquete, paquetes, tarifa, dniAutorizadoDespacho, direccionOrigen, direccionDestino, sucursalOrigen, sucursalDestino, estadoOrden);

        }

        public OrdenServicio conocerEstadoOrdenServicio(int idOrden)
        {
            var ctx = new TPContext();
            var ordenServicio = ctx.OrdenesServicio.Find(idOrden);
            Console.WriteLine(ordenServicio.EstadoOrden);
            return ordenServicio;
        }

        public static string validarNumeroOrden(int idOrden)
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

        public static OrdenServicio mostrarOrden(int idOrden)
        {
            var ctx = new TPContext();
            var ordenServicio = ctx.OrdenesServicio.Find(idOrden);

            Console.WriteLine("ID: " + ordenServicio.OrdenServicioID + " | Estado de orden: " +ordenServicio.EstadoOrden);
            Console.WriteLine("--------");

            return ordenServicio;
        }

        public static void aprobarOrden(
            Cliente cliente,
            string prioridadServicio, 
            string entregaPaquete, 
            string retiroPaquete,
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
                Cliente = cliente,
                PrioridadServicio = prioridadServicio,
                EntregaPaquete = entregaPaquete,
                RetiroPaquete = retiroPaquete,
                Paquetes = paquetes,
                TarifaFinal = tarifa,
                DniAutorizadoDespacho = dniAutorizadoDespacho,
                DireccionOrigen = direccionOrigen,
                DireccionDestino = direccionDestino,
                SucursalOrigen = sucursalOrigen,
                SucursalDestino = sucursalDestino,
                EstadoOrden = estadoOrden
            };
            ctx.OrdenesServicio.Add(ordenServicio);
            ctx.SaveChanges();
            Console.WriteLine("******************************");
            Console.WriteLine("* Orden de servicio generada *");
            Console.WriteLine("******************************");
        }
    }
}
