using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaClasesBD;

namespace LibreriaRequest_ResponseCaja
{
    public class ObtenerMetPagoResponses
    {
        public bool estado { get; set; }
        public List<Met_Pagos> metodos_pago { get; set; }
    }
}
