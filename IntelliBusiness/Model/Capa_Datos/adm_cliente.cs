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
    
    public partial class adm_cliente
    {
        public adm_cliente()
        {
            this.ven_venta = new HashSet<ven_venta>();
        }
    
        public int id { get; set; }
        public Nullable<long> gcm { get; set; }
    
        public virtual adm_usuario adm_usuario { get; set; }
        public virtual ICollection<ven_venta> ven_venta { get; set; }
    }
}
