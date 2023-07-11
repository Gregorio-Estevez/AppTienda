using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Registro_Cliente
    {
        public int id_registro { get; set; }
        public Cliente cliente { get; set; }
        public string tiempo_conexion { get; set; }
    }
}
