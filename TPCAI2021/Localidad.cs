using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCAI2021
{
    [Table("Localidades")]
    class Localidad
    {
        public int LocalidadID { get; set; }
        public string Nombre { get; set; }
        public Provincia Provincia { get; set; }
        public ICollection<Sucursal> Sucursales { get; set; }
    }
}
