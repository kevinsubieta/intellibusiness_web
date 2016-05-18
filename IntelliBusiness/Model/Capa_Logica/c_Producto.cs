using Model.Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Capa_Logica
{
    class c_producto
    {
        public List<inv_producto> Get_All()
        {
            return new IntellibusinessEntities().inv_producto.OrderBy(x => x.nombre).ToList();
        }

        public inv_producto Get(int id)
        {
            IntellibusinessEntities db = new IntellibusinessEntities();

            var query = db.inv_producto.OrderBy(x => x.nombre);

            if (query == null || query.Count() < 1) return null;
            return query.ElementAt(0);
        }

        public bool Registrar(string nombre, List<inv_valorescalar> escalares, List<inv_productonumerico> numericas )
        {
            if (!Validar(nombre)) return false;

            inv_producto aux = new inv_producto()
            {
                nombre = nombre,
                inv_valorescalar = escalares,
                inv_productonumerico = numericas,
            };

            using (var db = new IntellibusinessEntities())
            {
                db.inv_producto.Add(aux);
                db.SaveChanges();
            }

            return true;
        }

        public bool Actualizar(int id, string nombre, List<inv_valorescalar> escalares, List<inv_productonumerico> numericas)
        {
            if (!Validar(nombre)) return false;

            using (var db = new IntellibusinessEntities())
            {
                var query = db.inv_producto.Where(x => x.id == id);

                if (query != null && query.Count() > 0)
                {
                    query.ElementAt(0).nombre = nombre;
                    query.ElementAt(0).inv_valorescalar = escalares;
                    query.ElementAt(0).inv_productonumerico = numericas;
                    db.SaveChanges();
                }
            }
            return true;
        }

        private bool Validar(string nombre)
        {
            if (nombre == null || nombre.Length > 50) return false;
            return true;
        }
    }
}
