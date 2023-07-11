using LibreriaClasesBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaRequest_ResponseCaja
{
    public class ObtenerCategoriaEmpleadoResponses
    {
        public bool estado { get; set; }
        public List<Categoria_Empleado> categoria { get; set; }
    }
}
