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
    
    public partial class Estado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estado()
        {
            //this.Clientes = new HashSet<Cliente>();
            //this.Compras_Proveedores = new HashSet<Compras_Proveedores>();
            //this.Detalles_Fact_Alquiler = new HashSet<Detalles_Fact_Alquiler>();
            //this.Detalles_Fact_Reparaciones = new HashSet<Detalles_Fact_Reparaciones>();
            //this.Empleados = new HashSet<Empleado>();
            //this.Historico_Cliente = new HashSet<Historico_Cliente>();
            //this.Historico_Empleados = new HashSet<Historico_Empleados>();
        }
    
        public int id_estado { get; set; }
        public string descripcion { get; set; }
        public System.DateTime fecha_ingreso { get; set; }
        public bool activo { get; set; }
        public string nombre_estado { get; set; }
    
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Cliente> Clientes { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Compras_Proveedores> Compras_Proveedores { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Detalles_Fact_Alquiler> Detalles_Fact_Alquiler { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Detalles_Fact_Reparaciones> Detalles_Fact_Reparaciones { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Empleado> Empleados { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Historico_Cliente> Historico_Cliente { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Historico_Empleados> Historico_Empleados { get; set; }
    }
}
