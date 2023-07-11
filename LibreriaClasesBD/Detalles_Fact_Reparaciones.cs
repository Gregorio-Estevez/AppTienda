using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Detalles_Fact_Reparaciones
    {
		public int id_det_fact { get; set; }
		public Factura factura { get; set; }
		public string nombre_producto { get; set; }
		public Categoria_Producto categoria_producto { get; set; }
		public string descripcion_producto { get; set; }
		public string descripcion_problema { get; set; }
		public decimal valor_reparacion { get; set; }
		public DateTime fecha_registro { get; set; }
		public DateTime fecha_entrega { get; set; }
		public Estados estado { get; set; }
	}
}
