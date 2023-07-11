using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaRequest_ResponseCaja
{
    public class LoginEmpleadoRequest
    {
        public string cedula { get; set; }
        public string hash_password { get; set; }
    }
}
