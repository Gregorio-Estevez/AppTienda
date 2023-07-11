using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Inventario
    {
		public int id_registro { get; set; }
		public Productos producto { get; set; }
		public int cant_stock { get; set; }
		public int cant_camino { get; set; }
		public int punto_reorden { get; set; }
		public Sucursales sucursal { get; set; }
	}
}
