using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaClasesBD;

namespace LibreriaRequest_ResponseCaja
{
    public class ObtenerDetallesComprasProveedoresResponses
    {
        public int estado { get; set; }
        public List<Compra_Producto> detalles_compra { get; set; }
    }
}
