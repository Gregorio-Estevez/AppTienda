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
    
    public partial class Detalles_Fact_Alquiler
    {
        public int id_det_fact { get; set; }
        public int id_factura { get; set; }
        public int id_producto { get; set; }
        public decimal precio_alquiler { get; set; }
        public System.DateTime fecha_alquilado { get; set; }
        public System.DateTime fecha_retorno { get; set; }
        public System.DateTime fecha_retornado { get; set; }
        public decimal mora { get; set; }
        public System.DateTime fecha_registro { get; set; }
        public int id_estado { get; set; }
    
        public virtual Estado Estado { get; set; }
        public virtual Factura Factura { get; set; }
        public virtual Producto Producto { get; set; }
    }
}