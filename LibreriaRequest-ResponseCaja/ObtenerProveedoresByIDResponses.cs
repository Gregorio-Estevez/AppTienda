using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaClasesBD;

namespace LibreriaRequest_ResponseCaja
{
    public class ObtenerProveedoresByIDResponses
    {
        public bool estado { get; set; }
        public Proveedores proveedor { get; set; }
    }
}
