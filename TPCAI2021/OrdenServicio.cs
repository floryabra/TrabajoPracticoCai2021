using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAI2021
{
    class OrdenServicio
    {
        public int nroOrdenServicio;
        public TipoServicio tipoServicio;
        public Paquete paquete;
        public string estadoOrden;
        public Direccion direccionOrigen;
        public Direccion direccionDestino;
        public decimal tarifa;
        public int dniAutorizadoDespacho;

        public OrdenServicio(int nroOrdenServicio, TipoServicio tipoServicio, Paquete paquete, string estadoOrden, Direccion direccionOrigen, Direccion direccionDestino, decimal tarifa, int dniAutorizadoDespacho)
        {
            this.nroOrdenServicio = nroOrdenServicio;
            this.tipoServicio = tipoServicio;
            this.paquete = paquete;
            this.estadoOrden = estadoOrden;
            this.direccionOrigen = direccionOrigen;
            this.direccionDestino = direccionDestino;
            this.tarifa = tarifa;
            this.dniAutorizadoDespacho = dniAutorizadoDespacho;
        }

        public static string realizarOrdenServicio()
        {
            Console.Clear();
            Console.WriteLine("Nueva orden de servicio");

            // 1 - Selección de la provincia de origen
            string idProvinciaSeleccionadaOrigen = mostrarProvincias();
            if (idProvinciaSeleccionadaOrigen == "volver")
            {
                return "volver";
            }

            List<Provincia> provincias = Provincia.listaProvincias();
            int indexProvinciaOrigen = int.Parse(idProvinciaSeleccionadaOrigen) - 1;
            int regionOrigen = provincias.ElementAt(indexProvinciaOrigen).idRegion;


            // 2 - Selección de sucursal o domicilio de origen
            Console.WriteLine("¿Desea enviar el paquete desde su domicilio o desde una sucursal?");
            Console.WriteLine("1) Sucursal");
            Console.WriteLine("2) Domicilio");
            string origenEnvio = Console.ReadLine();
            if (origenEnvio == "1") {

                string idSucursalOrigen = mostrarSucursales(idProvinciaSeleccionadaOrigen);

            } else if (origenEnvio == "2")
            {
                //TODO: Cargar datos de domicilio de origen
            } else
            {
                return "volver";
            }


            // 3 - Destino nacional o internacional
            Console.WriteLine("¿El destino es nacional?");
            Console.WriteLine("1) Si");
            Console.WriteLine("2) No");
            string destinoNacional = Console.ReadLine();
            if (destinoNacional == "1")
            {

                string idProvinciaSeleccionadaDestino = mostrarProvincias();
                if (idProvinciaSeleccionadaDestino == "volver")
                {
                    return "volver";
                }

                int indexProvinciaDestino = int.Parse(idProvinciaSeleccionadaDestino) - 1;
                int regionDestino = provincias.ElementAt(indexProvinciaDestino).idRegion;

            }
            else if (destinoNacional == "2")
            {
                Console.WriteLine("Seleccione la región de destino");
                Console.WriteLine("1) Países limítrofes");
                Console.WriteLine("2) Resto de América Latina");
                Console.WriteLine("3) América del Norte");
                Console.WriteLine("4) Europa");
                Console.WriteLine("5) Asia");

                // TODO: Seleccionar país según región
            }
            else
            {
                return "volver";
            }


            // 4 - Entrega en sucursal o particular
            Console.WriteLine("¿La entrega es en sucursal o domicilio?");
            Console.WriteLine("1) Sucursal");
            Console.WriteLine("2) Domicilio");
            string tipoEntrega = Console.ReadLine();
            if (tipoEntrega == "1")
            {

                //string idSucursalOrigen = mostrarSucursales(idProvinciaSeleccionadaDestino);

            }
            else if (tipoEntrega == "2")
            {

                // TODO: Cargar datos domicilio destino
            }
            else
            {
                return "volver";
            }

            // 5 - Entrega urgente
            Console.WriteLine("¿Es entrega urgente?");
            Console.WriteLine("1) Si (recargo del 10% con tope a $500 en el precio fina)");
            Console.WriteLine("2) No");
            string urgencia = Console.ReadLine();


            // 6 - Detalles del paquete
            Paquete.ingresarPaquete();

            // 7 - Cálculo de tarifa
            return "test realizarOrdenServicio";
        }

        private static string mostrarProvincias()
        {
            Console.WriteLine("Seleccione la provincia de origen");
            List<Provincia> provincias = Provincia.listaProvincias();

            foreach (Provincia prov in provincias)
            {
                Console.WriteLine(prov.idProvincia + ")" + prov.nombreProvincia);
            }
            Console.WriteLine("S) Salir");

            string seleccion = Console.ReadLine();
            if (seleccion == "S")
            {
                return "volver";
            } else
            {
                return seleccion;
            }
        }

        private static string mostrarSucursales(string idProvincia)
        {
            Console.WriteLine("Seleccione la sucursal de origen");
            List<Sucursal> sucursales = Sucursal.listaSucursales(int.Parse(idProvincia));

            foreach (Sucursal sucu in sucursales)
            {
                Console.WriteLine(sucu.SucursalId + ")" + sucu.Nombre);
            }
            Console.WriteLine("S) Salir");

            string seleccion = Console.ReadLine();
            if (seleccion == "S")
            {
                return "volver";
            }
            else
            {
                return seleccion;
            }
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

        public string aprobarOrden()
        {
            return "test aprobarOrden";
        }
    }
}
