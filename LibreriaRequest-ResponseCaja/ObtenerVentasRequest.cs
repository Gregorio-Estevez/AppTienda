using LibreriaClasesBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaRequest_ResponseCaja
{
    public class ObtenerVentasRequest
    {
        public Sucursales sucursal { get; set; }
        public int id_servicio { get; set; }
    }
}
