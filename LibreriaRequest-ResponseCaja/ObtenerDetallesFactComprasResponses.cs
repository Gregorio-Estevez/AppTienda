using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaClasesBD;

namespace LibreriaRequest_ResponseCaja
{
    public class ObtenerDetallesFactComprasResponses
    {
        public bool estado { get; set; }
        public List<Detalles_Fact_Compras> detalles_compra { get; set; }
    }
}
