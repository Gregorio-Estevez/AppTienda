using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaClasesBD;

namespace LibreriaRequest_ResponseCaja
{
    public class ObtenerProductosByIDResponses
    {
        public bool estado { get; set; }
        public Productos Producto { get; set; }
    }
}
