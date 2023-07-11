using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Detalles_Fact_Alquiler
    {
		public int id_det_fact { get; set; }
		public Factura factura { get; set; }
		public Productos producto { get; set; }
		public decimal precio_alquiler { get; set; }
		public DateTime fecha_alquilado { get; set; }
		public DateTime fecha_retorno { get; set; }
		public DateTime fecha_retornado { get; set; }
		public decimal mora { get; set; }
		public Estados estado { get; set; }
	}
}
