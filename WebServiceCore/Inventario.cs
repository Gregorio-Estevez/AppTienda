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
    
    public partial class Inventario
    {
        public int id_registro { get; set; }
        public int id_producto { get; set; }
        public int cant_stock { get; set; }
        public int cant_camino { get; set; }
        public int punto_reorden { get; set; }
        public int id_sucursal { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual Sucursale Sucursale { get; set; }
    }
}
