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
    
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
            this.Facturas = new HashSet<Factura>();
            this.Historico_Empleados = new HashSet<Historico_Empleados>();
            this.Info_Registro_Empleados = new HashSet<Info_Registro_Empleados>();
            this.Registro_Empleados = new HashSet<Registro_Empleados>();
        }
    
        public int id_empleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int id_tipo_empleado { get; set; }
        public string email { get; set; }
        public string cedula { get; set; }
        public decimal salario { get; set; }
        public System.DateTime fecha_nac { get; set; }
        public System.DateTime fecha_registro { get; set; }
        public string direccion { get; set; }
        public string num_telefono { get; set; }
        public int id_estado { get; set; }
        public int id_sucursal { get; set; }
        public string ruta_foto { get; set; }
    
        public virtual Categoria_Empleados Categoria_Empleados { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Sucursale Sucursale { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura> Facturas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historico_Empleados> Historico_Empleados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Info_Registro_Empleados> Info_Registro_Empleados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registro_Empleados> Registro_Empleados { get; set; }
    }
}