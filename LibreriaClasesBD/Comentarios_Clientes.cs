using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Comentarios_Clientes
    {
        public int id_comentario { get; set; }
        public decimal calificacion { get; set; }
        public string comentario { get; set; }
        public Cliente cliente { get; set; }
        public int producto { get; set; }
    }
}
