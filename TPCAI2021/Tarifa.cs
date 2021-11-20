using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCAI2021.data;

namespace TPCAI2021
{
    class Tarifa
    {
        public int TarifaID { get; set; }
        public double PesoMaximo { get; set; }
        public int Local { get; set; }
        public int Provincial { get; set; }
        public int Regional { get; set; }
        public int Nacional { get; set; }
        public int InternacionalLimitrofe { get; set; }
        public int InternacionalALatina { get; set; }
        public int InternacionalANorte { get; set; }
        public int InternacionalEuropa { get; set; }
        public int InternacionalAsia { get; set; }

        public static Tarifa obtenerTarifario(double peso)
        {
            var ctx = new TPContext();
            var tarifa = ctx.Tarifas
                    .Where(s => s.PesoMaximo > peso)
                    //.OrderByDescending(s => s.PesoMaximo)
                    .FirstOrDefault<Tarifa>();
            return tarifa;
        }
    }
}
