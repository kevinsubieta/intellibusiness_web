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
    
    public partial class inv_producto
    {
        public inv_producto()
        {
            this.inv_productonumerico = new HashSet<inv_productonumerico>();
            this.inv_productoempresa = new HashSet<inv_productoempresa>();
            this.inv_valorescalar = new HashSet<inv_valorescalar>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
    
        public virtual ICollection<inv_productonumerico> inv_productonumerico { get; set; }
        public virtual ICollection<inv_productoempresa> inv_productoempresa { get; set; }
        public virtual ICollection<inv_valorescalar> inv_valorescalar { get; set; }
    }
}
