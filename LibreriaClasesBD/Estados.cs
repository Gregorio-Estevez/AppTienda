using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Estados
    {
        public int id_estado { get; set; }
        public string nombre_estado { get; set; }
        public string descripcion { get; set; }
	    public bool activo { get; set; }
        public int tipo_estado { get; set; }
    }
}
