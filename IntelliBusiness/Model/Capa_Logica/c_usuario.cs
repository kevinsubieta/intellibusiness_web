using Model.Capa_Datos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Model.Capa_Logica
{
    public class c_usuario
    {
        public adm_representante get_representante(string user,string pass)
        {
            IntellibusinessEntities db = new IntellibusinessEntities();
            var query = db.adm_representante.Where(x => x.adm_usuario.loggin == user && x.baja == false).ToList();
            if (query == null || query.Count() < 1) return null;
            adm_representante aux = query[0];

            //___Para Inicializar Carpetas y archivos 
            //string systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "/ISFiles/Keys";
            //Directory.CreateDirectory(systemPath);
            //BinaryWriter escritor = new BinaryWriter(new FileStream(systemPath+"/0", FileMode.Create));
            //escritor.Write(encrypt("12345"));
            //escritor.Close();
            //escritor = new BinaryWriter(new FileStream(systemPath+"/1", FileMode.Create));
            //escritor.Write(encrypt("12345"));
            //escritor.Close();
            //______________________________________
            if (!verif_password(aux.usuario, pass)) return null;
            return aux;            
        }

        public adm_administrador get_administrador(string user, string pass)
        {
            IntellibusinessEntities db = new IntellibusinessEntities();
            var query = db.adm_administrador.Where(x => x.adm_usuario.loggin == user && x.baja == false).ToList();
            if (query == null || query.Count() < 1) return null;
            adm_administrador aux = query[0];
            if (!verif_password(aux.id, pass)) return null;
            return aux;  
        }

        public adm_cliente get_cliente(string user, string pass)
        {
            IntellibusinessEntities db = new IntellibusinessEntities();
            var query = db.adm_cliente.Where(x => x.adm_usuario.loggin == user).ToList();
            if (query == null || query.Count() < 1) return null;
            adm_cliente aux = query[0];
            if (!verif_password(aux.id, pass)) return null;
            return aux; 
        }

        public bool verif_password(int id,string pass)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "/ISFiles/Keys/" + Convert.ToString(id);
            if (!File.Exists(path)) return false;
            BinaryReader lector = new BinaryReader(File.Open(path, FileMode.Open));
            string password = lector.ReadString();
            lector.Close();
            if (encrypt(pass) != password) return false;
            return true;            
        }

        public string encrypt(string cadena)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                return String.Join("", hash.ComputeHash(Encoding.UTF8.GetBytes(cadena)).Select(item => item.ToString("x2")));
            }
        }


    }
}
