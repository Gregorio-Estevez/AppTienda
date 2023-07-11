using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaClasesBD;
namespace LibreriaRequest_ResponseCaja
{
    public class RegistrarCompraProveedoresRequest
    { 
        public Compras_Proveedores compra { get; set; }
        public List<Compra_Producto> productoscomprados { get; set; }
    }
}
