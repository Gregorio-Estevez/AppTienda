using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaClasesBD;

namespace LibreriaRequest_ResponseCaja
{
    public class ObtenerClientesCoindicanResponses
    {
        public bool estado { get; set; }
        public List<Cliente> cliente { get; set; }
    }
}
