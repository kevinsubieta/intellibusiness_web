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
    
    public partial class mrk_descuento
    {
        public mrk_descuento()
        {
            this.inv_productoempresa = new HashSet<inv_productoempresa>();
        }
    
        public int id { get; set; }
        public string descripcion { get; set; }
        public long inicio { get; set; }
        public long fin { get; set; }
        public byte porcentaje { get; set; }
        public bool baja { get; set; }
    
        public virtual ICollection<inv_productoempresa> inv_productoempresa { get; set; }
    }
}
