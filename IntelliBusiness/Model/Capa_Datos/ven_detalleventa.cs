//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.Capa_Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class ven_detalleventa
    {
        public long venta { get; set; }
        public int producto { get; set; }
        public int cantidad { get; set; }
    
        public virtual inv_productoempresa inv_productoempresa { get; set; }
        public virtual ven_venta ven_venta { get; set; }
    }
}
