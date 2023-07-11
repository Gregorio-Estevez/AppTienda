using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Compra_Producto
    {
        public int id_registro { get; set; }
        public Productos producto { get; set; }
        public Compras_Proveedores compra { get; set; }
        public int cant_ordenado { get; set; }
        public decimal precio_unitario { get; set; }
    }
}
