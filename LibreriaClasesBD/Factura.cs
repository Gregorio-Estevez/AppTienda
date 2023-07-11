using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClasesBD
{
    public class Factura
    {
		public int id_factura { get; set; }
		public Met_Pagos metpago { get; set; }
		public Empleado empleado { get; set; }
		public decimal subtotal_servicio { get; set; }
		public Tipo_Compra tipo_compra { get; set; }
		public decimal impuestos { get; set; }
		public decimal total_descuento { get; set; }
		public decimal monto_total { get; set; }
		public string ncf { get; set; }
		public DateTime vencimiento_fact { get; set; }
		public string nombre_cliente { get; set; }
		public Cliente cliente { get; set; }
		public bool entrega_domicilio { get; set; }
		public Sucursales sucursal { get; set; }
		public Servicios servicio { get; set; }
	}
}
