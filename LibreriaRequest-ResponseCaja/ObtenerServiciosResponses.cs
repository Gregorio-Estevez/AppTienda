using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaClasesBD;

namespace LibreriaRequest_ResponseCaja
{
    public class ObtenerServiciosResponses
    {
        public bool estado { get; set; }
        public List<Servicios> servicios {get; set;}
    }
}
