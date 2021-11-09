using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAI2021
{
    [Table("Direcciones")]
    class Direccion
    {
        public int DireccionId { get; set; }
        public bool AlcanceNacional { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int CodigoPostal { get; set; }
        public int? Piso { get; set; }
        public char? Depto { get; set; }

        public string ingresarDireccion()
        {
            return "test ingresarDireccion";
        }
    }
}
