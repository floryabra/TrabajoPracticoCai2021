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

            Localidad localidadOrigen = null;
            Localidad localidadDestino = null;

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

            while (true)
            {
                bool idProvinciaOrigenValida = int.TryParse(Console.ReadLine(), out idProvinciaOrigen);
                if (idProvinciaOrigenValida)
                {

                    provinciaOrigen = Provincia.getProvincia(idProvinciaOrigen);
                    if (provinciaOrigen == null)
                    {
                        Console.WriteLine("El número ingresado no corresponde a una provincia");
                    } else
                    {
                        break;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Debe ingresar un número");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Seleccione la localidad de origen:");
            Localidad.listarLocalidadesPorProvincia(idProvinciaOrigen);

            while (true)
            {
                bool idLocalidadOrigenValida = int.TryParse(Console.ReadLine(), out idLocalidadOrigen);
                if (idLocalidadOrigenValida)
                {

                    localidadOrigen = Localidad.getLocalidad(idLocalidadOrigen);

                    if (localidadOrigen == null)
                    {
                        Console.WriteLine("El número ingresado no corresponde a una localidad");
                    }
                    else if (localidadOrigen.ProvinciaID != idProvinciaOrigen)
                    {
                        Console.WriteLine("La localidad seleccionada no corresponde a la provincia seleccionada");
                    }
                    else
                    {
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("Debe ingresar un número");
                }
            }
            
            
            // 2 - Selección de sucursal o en puerta de origen
            Console.WriteLine("***********");
            Console.WriteLine("El retiro del paquete será:");
            Console.WriteLine("1) En sucursal");
            Console.WriteLine("2) En puerta");
            Console.WriteLine("");
            string origenEnvio;

            while (true)
            {
                origenEnvio = Console.ReadLine();
                if (origenEnvio == "1" || origenEnvio == "2")
                {
                    break;
                } else
                {
                    Console.WriteLine("La opción seleccionada no es válida");
                }
            }

            string retiroPaquete = "";
            if (origenEnvio == "1")
            {
                Console.WriteLine("");
                Console.WriteLine("Seleccione la sucursal de origen:");
                Sucursal.listarSucursales(idLocalidadOrigen);

                int idSucursalOrigen;

                while (true)
                {
                    bool idSucursalOrigenValida = int.TryParse(Console.ReadLine(), out idSucursalOrigen);
                    if (idSucursalOrigenValida)
                    {

                        sucursalOrigen = Sucursal.getSucursal(idSucursalOrigen);

                        if (sucursalOrigen == null)
                        {
                            Console.WriteLine("El número ingresado no corresponde a una sucursal");
                        }
                        else if (sucursalOrigen.LocalidadID != idLocalidadOrigen)
                        {
                            Console.WriteLine("La sucursal seleccionada no corresponde a la localidad seleccionada");
                        }
                        else
                        {
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un número");
                    }
                }
                retiroPaquete = "Sucursal";
            }
            else if (origenEnvio == "2")
            {
                direccionOrigen = Direccion.ingresarDireccion(idLocalidad: idLocalidadOrigen);
                retiroPaquete = "Puerta";
            }

            // 3 - Destino nacional o internacional
            Console.WriteLine("***********");
            Console.WriteLine("El envío del paquete será: ");
            Console.WriteLine("1) Nacional");
            Console.WriteLine("2) Internacional");
            Console.WriteLine("");

            string destinoNacional;
            while (true)
            {
                destinoNacional = Console.ReadLine();
                if (destinoNacional == "1" || destinoNacional == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("La opción seleccionada no es válida");
                }
            }

            if (destinoNacional == "1")
            {
                Console.WriteLine("");
                Console.WriteLine("Seleccione la provincia de destino:");
                Provincia.listarProvincias();

                while (true)
                {
                    bool idProvinciaDestinoValida = int.TryParse(Console.ReadLine(), out idProvinciaDestino);
                    if (idProvinciaDestinoValida)
                    {

                        provinciaDestino = Provincia.getProvincia(idProvinciaDestino);

                        if (provinciaDestino == null)
                        {
                            Console.WriteLine("El número ingresado no corresponde a una provincia");
                        }
                        else
                        {
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un número entero");
                    }
                }
                

                Console.WriteLine("");
                Console.WriteLine("Seleccione la localidad de destino:");
                Localidad.listarLocalidadesPorProvincia(idProvinciaDestino);

                while (true)
                {
                    bool idLocalidadDestinoValida = int.TryParse(Console.ReadLine(), out idLocalidadDestino);
                    if (idLocalidadDestinoValida)
                    {

                        localidadDestino = Localidad.getLocalidad(idLocalidadDestino);

                        if (localidadDestino == null)
                        {
                            Console.WriteLine("El número ingresado no corresponde a una localidad");
                        }else if (localidadDestino.ProvinciaID != idProvinciaDestino)
                        {
                            Console.WriteLine("La localidad no corresponde a la provincia seleccionada");
                        }
                        else
                        {
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un número entero");
                    }
                }
                

            }
            else if (destinoNacional == "2")
            {
                Console.WriteLine("");
                Console.WriteLine("Seleccione el pais de destino:");
                Pais.listarPaises();
                idLocalidadDestino = 17; // En los envíos internacionales el paquete viaja a CABA.
                idProvinciaDestino = 6;
                provinciaDestino = Provincia.getProvincia(idProvinciaDestino);

                while (true)
                {
                    bool idPaisDestinoValido = int.TryParse(Console.ReadLine(), out idPaisDestino);
                    if (idPaisDestinoValido)
                    {

                        paisDestino = Pais.getPais(idPaisDestino);

                        if (paisDestino == null)
                        {
                            Console.WriteLine("El número ingresado no corresponde a un país");
                        }
                        else
                        {
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un número entero");
                    }
                }

            }

            // 4 - Entrega en sucursal o particular
            Console.WriteLine("***********");
            Console.WriteLine("La entrega del paquete será:");
            Console.WriteLine("1) En Sucursal");
            Console.WriteLine("2) En Puerta");
            Console.WriteLine("");
            string tipoEntrega;
            int opcionTipoEntrega = 0;

            while (true)
            {
                bool tipoEntregaValido = int.TryParse(Console.ReadLine(), out opcionTipoEntrega);
                if (tipoEntregaValido)
                {

                    if (opcionTipoEntrega == 1 || opcionTipoEntrega == 2 )
                    {
                        tipoEntrega = opcionTipoEntrega.ToString();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("El número ingresado no corresponde a una opción válida");
                        
                    }

                }
                else
                {
                    Console.WriteLine("Debe ingresar un número entero");
                }
            }

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
                

                int idSucursalDestino = 0;
                while (true)
                {
                    bool idSucursalDestinoValido = int.TryParse(Console.ReadLine(), out idSucursalDestino);
                    if (idSucursalDestinoValido)
                    {

                        sucursalDestino = Sucursal.getSucursal(idSucursalDestino);
                        entregaPaquete = "Sucursal";

                        if (sucursalDestino == null)
                        {
                            Console.WriteLine("El número ingresado no corresponde a una sucursal");
                        }
                        else
                        {
                            if ((destinoNacional == "1" && sucursalDestino.LocalidadID != idLocalidadDestino) || (destinoNacional == "2" && sucursalDestino.PaisID != idPaisDestino))
                            {
                                Console.WriteLine("El número de sucursal no corresponde al destino seleccionado");
                            }
                            else 
                            {
                                break;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un número entero");
                    }
                }
                

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

                entregaPaquete = "Puerta";

            }

            // 5 - Entrega urgente
            Console.WriteLine("***********");
            Console.WriteLine("¿El tipo de servicio que desea realizar, es urgente?  (Se entrega en 48hs, recargo del 10%). Ingrese S o N.");
            Console.WriteLine("");
            string urgencia;

            while (true)
            {
                urgencia = Console.ReadLine().ToLower();
                if (urgencia == "s" || urgencia == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Debe ingresar S o N");
                }
            }

            // 6 - Detalles del paquete
            Console.WriteLine("***********");
            List<Paquete> paquetes = new List<Paquete>();
            while (true)
            {
                paquetes.Add(Paquete.ingresarPaquete());
                Console.WriteLine("¿Desea agregar otro paquete? S/N");
                string agregarMasPaquetes;
                while (true)
                {
                    agregarMasPaquetes = Console.ReadLine().ToLower();
                    if (agregarMasPaquetes == "s" || agregarMasPaquetes == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar S o N");
                    }
                }

                if (agregarMasPaquetes.ToLower() == "n")
                {
                    break;
                }
            }

            // 7 - Cálculo de tarifa
            Console.WriteLine("***********");
            double tarifa = 0;

            foreach(Paquete p in paquetes)
            {

                Console.WriteLine("----------");

                Tarifa tarifario = Tarifa.obtenerTarifario(p.Peso);

                Console.WriteLine("Peso del paquete: " + p.Peso.ToString());

                Console.WriteLine("DEBUG - Inicio tarifa: " + tarifa.ToString());

                if (destinoNacional == "2")
                {
                    Console.WriteLine("DEBUG - Aunque sea internacional, primero calculamos la tarifa hacia CABA");
                }

                if (idLocalidadOrigen == idLocalidadDestino)
                {
                    Console.WriteLine("DEBUG - Envío local +" + tarifario.Local.ToString());
                    tarifa += tarifario.Local;
                }
                else if (idProvinciaOrigen == idProvinciaDestino)
                {
                    Console.WriteLine("DEBUG - Envío provincial +" + tarifario.Provincial.ToString());
                    tarifa += tarifario.Provincial;
                }
                else if (provinciaOrigen.IdRegion == provinciaDestino.IdRegion)
                {
                    Console.WriteLine("DEBUG - Envío regional +" + tarifario.Regional.ToString());
                    tarifa += tarifario.Regional;
                }
                else
                {
                    Console.WriteLine("DEBUG - Envío interregional. +" + tarifario.Nacional.ToString());
                    tarifa += tarifario.Nacional;
                }

                if (destinoNacional == "2")
                {
                    Console.WriteLine("DEBUG - Tarifa hasta CABA: " + tarifa.ToString());
                }

                if (destinoNacional == "2")
                {
                    if (paisDestino.RegionID == 1)
                    {
                        Console.WriteLine("DEBUG - Internacional limitrofe. +" + tarifario.InternacionalLimitrofe.ToString());
                        tarifa += tarifario.InternacionalLimitrofe;
                    }
                    else if (paisDestino.RegionID == 2)
                    {
                        Console.WriteLine("DEBUG - Internacional A. Latina. +" + tarifario.InternacionalALatina.ToString());
                        tarifa += tarifario.InternacionalALatina;
                    }
                    else if (paisDestino.RegionID == 3)
                    {
                        Console.WriteLine("DEBUG - Internacional A. Norte. +" + tarifario.InternacionalANorte.ToString());
                        tarifa += tarifario.InternacionalANorte;
                    }
                    else if (paisDestino.RegionID == 4)
                    {
                        Console.WriteLine("DEBUG - Internacional A. Europa. +" + tarifario.InternacionalEuropa.ToString());
                        tarifa += tarifario.InternacionalEuropa;
                    }
                    else
                    {
                        Console.WriteLine("DEBUG - Internacional Asia. +" + tarifario.InternacionalAsia.ToString());
                        tarifa += tarifario.InternacionalAsia;
                    }
                }
                
                Console.WriteLine("DEBUG: Tarifa total por distancia: " + tarifa.ToString());

                if (retiroPaquete == "Puerta")
                {
                    tarifa += 50;
                    Console.WriteLine("DEBUG  +50 por ser retiro en puerta. Total: " + tarifa.ToString());
                }

                if (entregaPaquete == "Puerta")
                {
                    tarifa += 50;
                    Console.WriteLine("DEBUG  +50 por ser retiro en puerta. Total: " + tarifa.ToString());
                }
            }

            Console.WriteLine("DEBUG: Tarifa hasta acá: " + tarifa.ToString());
            string prioridadServicio = "No urgente";

            if (urgencia.ToLower() == "s")
            {
                double recargo = tarifa * 0.1;
                if (recargo > 500)
                {
                    recargo = 500;
                }
                Console.WriteLine("DEBUG - Recargo tarifa:" + recargo.ToString());

                tarifa += recargo;
                prioridadServicio = "Urgente";
            }
            Console.WriteLine("DEBUG: Tarifa total: " + tarifa.ToString());
            Console.WriteLine("***********");

            Console.WriteLine("Datos del servicio:");
            Console.WriteLine("Tipo de Servicio");
            Console.WriteLine("    Prioridad: " + prioridadServicio);
            Console.WriteLine("    Retiro: " + retiroPaquete);
            Console.WriteLine("    Entrega: " + entregaPaquete);

            Console.WriteLine("Paquetes:");
            int indexPaquetes = 0;
            foreach (Paquete p in paquetes)
            {
                Console.WriteLine("    ID Paquete: " + indexPaquetes.ToString());
                Console.WriteLine("    Tipo: " + p.TipoPaquete);
                Console.WriteLine("    Peso: " + p.Peso);
                Console.WriteLine("");
            }

            string textoOrigen;
            string textoDestino;

            if (retiroPaquete == "Puerta")
            {
                textoOrigen = direccionOrigen.Calle + ", " + direccionOrigen.Altura.ToString() + ", " + direccionOrigen.CodigoPostal.ToString() + ", " + localidadOrigen.Nombre;
            }
            else
            {
                textoOrigen = sucursalOrigen.Nombre;
            }

            if (entregaPaquete == "Puerta")
            {
                textoDestino = direccionDestino.Calle + ", " + direccionDestino.Altura.ToString() + ", "+ direccionDestino.CodigoPostal.ToString() + ", " + localidadDestino.Nombre;
            }
            else
            {
                textoDestino = sucursalDestino.Nombre;
            }
            Console.WriteLine("Dirección de Origen:");
            Console.WriteLine(textoOrigen);
            Console.WriteLine("Dirección de Destino:");
            Console.WriteLine(textoDestino);

            if (destinoNacional == "1")
            {
                Console.WriteLine("Alcance: Nacional");
            } else
            {
                Console.WriteLine("Alcance: Internacional");
            }

            Console.WriteLine("Tarifa: " + tarifa);

            // 8 - Confirmar servicio
            Console.WriteLine("*************************************");
            Console.WriteLine("* ¿Desea confirmar el servicio? S/N *");
            Console.WriteLine("*************************************");

            string confirmarServicio;
            while (true)
            {
                confirmarServicio = Console.ReadLine().ToLower();
                if (confirmarServicio == "n")
                {
                    return;
                } else if (confirmarServicio == "s")
                {
                    break;
                } else
                {
                    Console.WriteLine("Debe ingresar S o N");
                }
            }

            // 9 - Agregar DNI autorizado a despachar
            Console.WriteLine("***********");
            Console.WriteLine("¿Desea ingresar el DNI de un autorizado a despachar el servicio? S/N");
            int dniAutorizadoDespacho = 0;

            var ctx = new TPContext();
            var cliente = ctx.Clientes.Find(idCliente);

            string agregarDniAutorizado;
            while (true)
            {
                agregarDniAutorizado = Console.ReadLine().ToLower();

                if (agregarDniAutorizado == "s" || agregarDniAutorizado == "n")
                {
                    break;
                }else
                {
                    Console.WriteLine("Debe ingresar S o N");
                }
            }

            if (agregarDniAutorizado == "s")
            {
                while (true)
                {
                    Console.WriteLine("Ingrese el DNI del autorizado a despachar:");

                    bool dniAutorizadoDespachoValido = int.TryParse(Console.ReadLine(), out dniAutorizadoDespacho);
                    if (dniAutorizadoDespachoValido)
                    {
                        if (dniAutorizadoDespacho.ToString().Length != 8)
                        {
                            Console.WriteLine("Debe ingresar 8 digitos");
                        } else 
                        {
                            bool dniExisteEnAutorizadosCliente = cliente.ListaPersonalAutorizado.Contains(dniAutorizadoDespacho.ToString());
                            if (dniExisteEnAutorizadosCliente)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("El DNI ingresado no se encuentra en la lista de autorizados por el cliente");
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un número");
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
                return "El número ingresado no se corresponde a una orden de servicio";
            } else
            {
                return "ok";
            }
        }

        public static OrdenServicio mostrarOrden(int idOrden)
        {
            var ctx = new TPContext();
            var ordenServicio = ctx.OrdenesServicio.Find(idOrden);

            Console.WriteLine("El estado de la orden de Servicio " + ordenServicio.OrdenServicioID + " es: " +ordenServicio.EstadoOrden);
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
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Orden de servicio generada con el ID " + ordenServicio.OrdenServicioID + "*");
            Console.WriteLine("*****************************************");

            if (dniAutorizadoDespacho != 0)
            {
                Console.WriteLine("DNI Autorizado a despachar: " + dniAutorizadoDespacho.ToString());
            }

        }
    }
}
