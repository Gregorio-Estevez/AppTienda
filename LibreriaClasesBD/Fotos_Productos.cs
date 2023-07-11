using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Fotos_Productos
    {
        public int id_registro { get; set; }
        public Productos producto { get; set; }
        public string ruta_foto { get; set; }
        public bool activo { get; set; }
    }
}
