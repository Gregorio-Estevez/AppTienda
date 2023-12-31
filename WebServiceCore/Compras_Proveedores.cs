//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebServiceCore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Compras_Proveedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compras_Proveedores()
        {
            this.Compra_Producto = new HashSet<Compra_Producto>();
        }
    
        public int id_compra { get; set; }
        public string cod_envio { get; set; }
        public string descripcion { get; set; }
        public System.DateTime fecha_llegada { get; set; }
        public int id_proveedor { get; set; }
        public decimal valor_total { get; set; }
        public System.DateTime fecha_registro { get; set; }
        public int id_estado { get; set; }
        public int id_sucursal { get; set; }
        public int cant_productos_dif_ordenados { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra_Producto> Compra_Producto { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Proveedore Proveedore { get; set; }
        public virtual Sucursale Sucursale { get; set; }
    }
}
