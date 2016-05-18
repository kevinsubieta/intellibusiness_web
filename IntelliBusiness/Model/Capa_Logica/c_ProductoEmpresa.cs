using Model.Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Capa_Logica
{
    class c_productoempresa
    {
        public List<inv_productoempresa> Get_All(int empresa)
        {
            return new IntellibusinessEntities().inv_productoempresa.Where(x => x.empresa == empresa).OrderBy(y => y.nombre).ToList();
        }

        public inv_productoempresa Get(int id)
        {
            IntellibusinessEntities db = new IntellibusinessEntities();
            var query = db.inv_productoempresa.Where(x => x.id == id);
            if (query == null || query.Count() < 1) return null;
            return query.ElementAt(0);
        }

        public bool Registrar(int producto,int empresa,string nombre,int cantidad,decimal precio,byte estado,string detalle,List<inv_imagenproducto> imagenes)
        {
            
            inv_productoempresa aux = new inv_productoempresa()
            {
                producto = producto,
                empresa = empresa,
                nombre = nombre,
                cantidad = cantidad,
                precio = precio,
                estado = estado,
                detalle = detalle,
                inv_imagenproducto = imagenes
            };

            using (IntellibusinessEntities db = new IntellibusinessEntities())
            {
                db.inv_productoempresa.Add(aux);
                db.SaveChanges();  
            }           

            return true;
        }

        public void Actualizar(int id, int producto, int empresa, string nombre, int cantidad, decimal precio, byte estado, string detalle, List<inv_imagenproducto> imagenes)
        {
            using (var db = new IntellibusinessEntities())
            {
                var query = db.inv_productoempresa.Where(x => x.id == id);

                if (query != null && query.Count() > 0)
                {
                    query.ElementAt(0).producto = producto;
                    query.ElementAt(0).empresa = empresa;
                    query.ElementAt(0).nombre = nombre;
                    query.ElementAt(0).cantidad = cantidad;
                    query.ElementAt(0).nombre = nombre;
                    query.ElementAt(0).precio = precio;
                    query.ElementAt(0).estado = estado;
                    query.ElementAt(0).detalle = detalle;
                    query.ElementAt(0).inv_imagenproducto = imagenes;
                    db.SaveChanges();
                }
            }
        }


    }
}
