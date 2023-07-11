using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Detalles_Fact_Compras
    {
		public int id_det_fact { get; set;}
		public Factura factura { get; set; }
		public Productos producto { get; set; }
		public int cant_producto { get; set; }
		public decimal precio_unitario { get; set; }
		public decimal descuento { get; set; }
	}
}
