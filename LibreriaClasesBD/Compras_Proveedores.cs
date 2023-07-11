using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Compras_Proveedores
    {
		public int id_compra { get; set; }
		public string cod_envio { get; set; }
		public string descripcion { get; set; }
		public DateTime fecha_llegada { get; set; }
		public Proveedores proveedor { get; set; }
		public decimal valor_total { get; set; }
		public Estados estado { get; set; }
		public Sucursales sucursal { get; set; }
		public int cant_productos_dif_ordenados { get; set; }
	}
}
