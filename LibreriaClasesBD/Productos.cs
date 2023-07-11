using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Productos
    {
		public int id_producto { get; set; }
		public string nombre { get; set; }
		public bool activo { get; set; }
		public decimal precio { get; set; }
		public string descripcion { get; set; }
		public Categoria_Producto categoria { get; set; }
		public decimal descuento { get; set; }
		public int punto_reorden { get; set; }
		public List<string> foto_productos { get; set; }
	}
}
