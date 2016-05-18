using Model.Capa_Datos;
using Model.Capa_Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackOffice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            Session["administradores"] = new Dictionary<int, adm_administrador>();
            Session["representantes"] = new Dictionary<int, adm_representante>();
            return View();
        }

        public JavaScriptResult iniciarsesion(string user, string pass,byte type)
        {
            if (type == 0)
            {
                adm_representante aux = new c_usuario().get_representante(user,pass);
                if (aux != null)
                {
                    Dictionary<int, adm_representante> diccionario = (Dictionary<int, adm_representante>)Session["representantes"];
                    if (!diccionario.ContainsKey(aux.usuario)) diccionario.Add(aux.usuario, aux);
                    return JavaScript("entraremp("+aux.usuario+","+"0"+");");
                }
            }
            else
            {
                adm_administrador aux = new c_usuario().get_administrador(user, pass);
                if (aux != null)
                {
                    Dictionary<int, adm_administrador> diccionario = (Dictionary<int, adm_administrador>)Session["administradores"];
                    if (!diccionario.ContainsKey(aux.id)) diccionario.Add(aux.id, aux);
                    return JavaScript("entraradm(" + aux.id + "," + "1" + ");");
                }
            }
            return JavaScript("Errorlogin();");
        }

        public ActionResult entrar(int userid,int type) 
        {
            if (!verif_log(userid, type)) return View("Index");
            if (type == 0) return RedirectToAction("Index", "business");
            return RedirectToAction("Index","administration");
        }

        private bool verif_log(int userid, int usertype)
        {
            if (usertype == 0)
                return ((Dictionary<int, adm_representante>)Session["representantes"]).ContainsKey(userid);

            return ((Dictionary<int, adm_administrador>)Session["administradores"]).ContainsKey(userid);
        }

    }
}
