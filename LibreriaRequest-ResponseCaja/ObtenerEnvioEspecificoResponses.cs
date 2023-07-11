using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaClasesBD;

namespace LibreriaRequest_ResponseCaja
{
    public class ObtenerEnvioEspecificoResponses
    {
        public Cliente cliente { get; set; }
        public Factura Factura { get; set; }
        public List<Detalles_Fact_Compras> compras { get; set; }
    }
}
