using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Proveedores
    {
		public int id_proveedor { get; set; }
		public string nombre { get; set; }
		public string rnc { get; set; }
		public bool activo { get; set; }
		public string email { get; set; }
		public string telefono { get; set; }
		public string direccion { get; set; }
	}
}
