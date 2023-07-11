using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Tarjeta_Credito
    {
		public int id_tarjeta_credito { get; set; }
		public Cliente cliente { get; set; }
		public string nombre_dueno { get; set; }
		public string num_tarjeta { get; set; }
		public string fecha_vencimiento { get; set; }
		public string cvv { get; set; }
		public bool activo { get; set; }
	}
}
