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
    
    public partial class ven_venta
    {
        public ven_venta()
        {
            this.ven_detalleventa = new HashSet<ven_detalleventa>();
        }
    
        public long nro { get; set; }
        public int cliente { get; set; }
        public long fecha { get; set; }
        public decimal monto { get; set; }
        public bool anulado { get; set; }
    
        public virtual adm_cliente adm_cliente { get; set; }
        public virtual ICollection<ven_detalleventa> ven_detalleventa { get; set; }
    }
}
