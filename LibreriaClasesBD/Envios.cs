using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Envios
    {
		public int id_envio { get; set; }
		public Cliente cliente { get; set; }
		public Factura factura { get; set; }
		public string direccion_envio { get; set; }
		public bool entregado { get; set; }
		public bool entrega_en_sucursal { get; set; }
	}
}
