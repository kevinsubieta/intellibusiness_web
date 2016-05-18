using Model.Capa_Datos;
using Model.Capa_Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackOffice.Controllers
{
    public class AdministrationController : Controller
    {

        public ActionResult Index(int userid)
        {
            if (!verif_log(userid)) return RedirectToAction("Index", "Home");
            return View();
        }

        public ActionResult perfil(int userid)
        {
            return View("_perfil");
        }

        public ActionResult empresas(int userid)
        {
            return View("_empresas");
        }

        public ActionResult usuarios(int userid)
        {
            return View("_usuarios");
        }

        public ActionResult productos(int userid)
        {
            return View("_productos");
        }

        public ActionResult propiedades(int userid)
        {
            ViewBag.escalares = new c_escalar().Get_All();
            ViewBag.numericos = new c_numerica().Get_All(); ;
            return View("_propiedades");
        }
        
        public ActionResult escalar(int userid, int escalarid, byte modo) //1 = registrar, 2 modificar
        {
            if (!verif_log(userid)) return salir(userid);
            if (escalarid != -1)
                ViewBag.escalar = new c_escalar().Get(escalarid);
            ViewBag.modo = modo;
            return View("_escalar");
        }

        public ActionResult salir(int userid)
        {
            ((Dictionary<int, adm_administrador>)Session["administradores"]).Remove(userid);
            TempData["lay"] = true;
            return RedirectToAction("Index", "home");
        }

        private bool verif_log(int userid)
        {
            return ((Dictionary<int, adm_administrador>)Session["administradores"]).ContainsKey(userid);
        }

        public void registrarescalar(string nombre, string[] valores)
        {

            if (nombre == null || nombre.Length < 1) return;
            if (valores == null) valores = new string[0];
            List<inv_valorescalar> values = new List<inv_valorescalar>();

            foreach (string valor in valores)
                values.Add( new inv_valorescalar() { valor = valor.Split(',').ElementAt(1), });

            new c_escalar().Registrar(nombre, values);            
        }

        public void actualizarescalar(int escalarid, string nombre, string[] valores)
        {
            if (nombre == null || nombre.Length < 1) return;
            if (valores == null) valores = new string[0];
            List<inv_valorescalar> nuevos = new List<inv_valorescalar>();
            List<inv_valorescalar> actualizados = new List<inv_valorescalar>();
            List<inv_valorescalar> eliminados = new List<inv_valorescalar>();

            foreach (string valor in valores)
            {
                string[] values = valor.Split(',');
                if (values[2] == "1")
                {
                    nuevos.Add(new inv_valorescalar() { valor = values[1] });
                }

                if (values[2] == "2")
                {
                    actualizados.Add(new inv_valorescalar() { id = Convert.ToByte(values[0]), valor = values[1] });
                }

                if (values[2] == "3")
                {
                    eliminados.Add(new inv_valorescalar() { id = Convert.ToByte(values[0]) });
                }
            }               

            new c_escalar().Actualizar(escalarid, nombre, nuevos, actualizados, eliminados);  
        }
    }
}
