using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Tipo_Compra
    {
        public int id_tipo_compra { get; set; }
        public string descripcion { get; set; }
	    public bool activo { get; set; }
    }
}
