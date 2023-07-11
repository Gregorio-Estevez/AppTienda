using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Sucursales
    {
        public int id_sucursal { get; set; }
        public string nombre_sucursal { get; set; }
        public string direccion_sucursal { get; set; }
        public DateTime fecha_registro { get; set; }
        public bool activo { get; set; }
    }
}
