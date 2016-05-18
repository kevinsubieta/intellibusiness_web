using Model.Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Capa_Logica
{
    public class c_escalar
    {
        public List<inv_escalar> Get_All()
        {            
            return new IntellibusinessEntities().inv_escalar.OrderBy(x => x.nombre).ToList();
        }

        public inv_escalar Get(int id)
        {
            IntellibusinessEntities db = new IntellibusinessEntities();
            var query = db.inv_escalar.Where(x => x.id == id).ToList();
            if (query == null || query.Count < 1) return null;
            return query[0];
        }

        public bool Registrar(string nombre , List<inv_valorescalar> valores)
        {
            if (!Validar(nombre, valores)) return false;

            for (byte i = 0; i < valores.Count; i++) valores[i].id = i;

            inv_escalar aux = new inv_escalar()
            {
                nombre = nombre,
                inv_valorescalar = valores
            };

            using (var db = new IntellibusinessEntities())
            {
                db.inv_escalar.Add(aux);
                db.SaveChanges();
            }
            return true;
        }

        public bool Actualizar(int id , string nombre , List<inv_valorescalar> nuevos, List<inv_valorescalar> actual, List<inv_valorescalar> elim)
        {
            if (!Validar(nombre, nuevos)) return false;
            if (!Validar(nombre, actual)) return false;
            int n = 0;

            using (var db = new IntellibusinessEntities())
            {
                var query = db.inv_escalar.Where(x => x.id == id).ToList();

                if (query != null && query.Count > 0)
                {
                    inv_escalar aux = query[0];
                    n = aux.inv_valorescalar.Last().id;
                    aux.nombre = nombre;
                    db.SaveChanges();
                } else { return false; }
            }

            c_valorescalar control = new c_valorescalar();
            foreach (var nuevo in nuevos)
            {
                n++;
                control.Registrar(id, n, nuevo.valor);                
            }                

            foreach (var a in actual)
                control.Actualizar(id, a.id, a.valor);

            foreach (var d in elim)
                control.Eliminar(id, d.id);

            return true;
        }

        private bool Validar(string nombre, List<inv_valorescalar> valores)
        {
            if (nombre == null || nombre.Length > 50) return false;
            foreach (var item in valores)
                if (item.valor == null || item.valor.Length > 50) return false;
            return true;                  
        }

    }
}
