using LibreriaClasesBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaRequest_ResponseCaja
{
    public class RegistrarVentasRequest
    {
        public Factura factura { get; set; }
        public Cliente cliente { get; set; }
        public List<Detalles_Fact_Compras> detalles_factura { get; set; }
    }
}
