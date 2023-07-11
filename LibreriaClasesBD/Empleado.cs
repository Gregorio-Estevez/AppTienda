using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Empleado
    {
		public int id_empleado { get; set; }
		public string nombre { get; set; }
		public string apellido { get; set; }
		public Categoria_Empleado tipo_empleado { get; set; } 
		public string email { get; set; }
		public string cedula { get; set; }
		public decimal salario { get; set; }
		public DateTime fecha_nac { get; set; }
		public DateTime fecha_registro { get; set; }
		public string direccion { get; set; }
		public string num_telefono { get; set; }
		public Estados estado { get; set; }
		public Sucursales sucursal { get; set; }
		public string ruta_foto { get; set; }
	}
}
