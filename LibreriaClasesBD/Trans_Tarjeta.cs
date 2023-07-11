using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Trans_Tarjeta
    {
        public int id_trans { get; set; }
        public Factura factuta { get; set; }
        public Tarjeta_Credito tarjeta { get; set; }
    }
}
