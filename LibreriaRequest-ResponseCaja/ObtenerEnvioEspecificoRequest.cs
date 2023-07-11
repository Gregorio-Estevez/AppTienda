using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaClasesBD;

namespace LibreriaRequest_ResponseCaja
{
    public class ObtenerEnvioEspecificoRequest
    {
        public Factura factura { get; set; }
        public Tipo_Compra Tipo_Compra { get; set; }
        public Cliente cliente { get; set; }
    }
}
