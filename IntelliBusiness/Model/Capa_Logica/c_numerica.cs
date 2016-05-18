using Model.Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Capa_Logica
{
    public class c_numerica
    {
        public List<inv_numerico> Get_All()
        {
            return new IntellibusinessEntities().inv_numerico.OrderBy(x => x.nombre).ToList();
        }

        public inv_numerico Get(int id)
        {
            IntellibusinessEntities db = new IntellibusinessEntities();

            var query = db.inv_numerico.Where(x => x.id == id);

            if (query == null || query.Count() < 1) return null;

            return query.ElementAt(0);
        }

        public bool Registrar(string nombre)
        {
            if (!Validar(nombre)) return false;

            inv_numerico aux = new inv_numerico() { nombre = nombre, };

            using (var db = new IntellibusinessEntities())
            {
                db.inv_numerico.Add(aux);
                db.SaveChanges();
            }
            return true;
        }

        public bool Actualizar(int id, string nombre)
        {
            if (!Validar(nombre)) return false;

            using (var db = new IntellibusinessEntities())
            {
                var query = db.inv_numerico.Where(x => x.id == id);

                if (query != null && query.Count() > 0)
                {
                    query.ElementAt(0).nombre = nombre;
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
