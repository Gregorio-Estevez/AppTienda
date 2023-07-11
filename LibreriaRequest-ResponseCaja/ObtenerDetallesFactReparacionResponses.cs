using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaClasesBD;
namespace LibreriaRequest_ResponseCaja
{
    public class ObtenerDetallesFactReparacionResponses
    {
        public bool estado { get; set; }
        public List<Detalles_Fact_Reparaciones> detalles_reparaciones { get; set; }
    }
}
