using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaClasesBD;

namespace LibreriaRequest_ResponseCaja
{
    public class ObtenerCategoriaProductoByIDResponses
    {
        public bool estado { get; set; }
        public Categoria_Producto categoria { get; set; }
    }
}
