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
    
    public partial class inv_productoempresa
    {
        public inv_productoempresa()
        {
            this.inv_imagenproducto = new HashSet<inv_imagenproducto>();
            this.ven_detalleventa = new HashSet<ven_detalleventa>();
            this.mrk_descuento = new HashSet<mrk_descuento>();
        }
    
        public int id { get; set; }
        public int producto { get; set; }
        public int empresa { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public byte estado { get; set; }
        public string detalle { get; set; }
    
        public virtual adm_empresa adm_empresa { get; set; }
        public virtual ICollection<inv_imagenproducto> inv_imagenproducto { get; set; }
        public virtual inv_producto inv_producto { get; set; }
        public virtual ICollection<ven_detalleventa> ven_detalleventa { get; set; }
        public virtual ICollection<mrk_descuento> mrk_descuento { get; set; }
    }
}
