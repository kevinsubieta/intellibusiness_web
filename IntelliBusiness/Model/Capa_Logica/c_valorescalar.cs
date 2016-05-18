using Model.Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Capa_Logica
{
    public class c_valorescalar
    {
        public bool Registrar(int escalar,int id, string nombre)
        {
            using (IntellibusinessEntities db = new IntellibusinessEntities())
            {
                db.inv_valorescalar.Add(new inv_valorescalar() { escalar = escalar, id = id, valor = nombre });
                db.SaveChanges();
            }            
            return true;
        }

        public bool Actualizar(int escalar, int id, string nombre)
        {
            using (IntellibusinessEntities db = new IntellibusinessEntities())
            {
                var query = db.inv_valorescalar.Where(x => x.escalar == escalar && x.id == id).ToList();
                if (query != null && query.Count > 0)
                {
                    query[0].valor = nombre;
                    db.SaveChanges();
                }                   
            }            
            return true;
        }

        public bool Eliminar (int escalar, int id)
        {
            using (IntellibusinessEntities db = new IntellibusinessEntities())
            {
                inv_valorescalar aux = new inv_valorescalar() { id = id };
                db.inv_valorescalar.Attach(aux);
                db.inv_valorescalar.Remove(aux);
                db.SaveChanges();
            }
            return true;
        }
    }
}
