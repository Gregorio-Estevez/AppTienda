using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaClasesBD;

namespace LibreriaRequest_ResponseCaja
{
    public class ObtenerReparacionEspecificoRequest
    {
        public Factura factura { get; set; }
        public Cliente cliente { get; set; }
    }
}
