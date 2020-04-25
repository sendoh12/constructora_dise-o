using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelos;
using System.Data.SqlClient;
using System.Threading;

namespace constructora_diseño.Controllers
{
    public class MenuController : Controller
    {
        Modelos.constructora_diseñoEntities contexto = new Modelos.constructora_diseñoEntities();
        // GET: Menu
        public ActionResult Menu_principal()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Inicio()
        {
            using (Repositorio<cd_roles> obj = new Repositorio<cd_roles>(contexto))
            {
                obj.Exception += Obj_Exception;
                ViewBag.data = obj.Filter(x => true);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Crear(string USUARIOS_NOMBRE, string USUARIOS_USUARIO, string USUARIOS_CONTRASEÑA, int USUARIOS_ROL)
        {
            Thread.Sleep(5000);
            using(Repositorio<cd_usuarios> obj = new Repositorio<cd_usuarios>(contexto))
            {
                obj.Exception += Obj_Exception;
                obj.Create(new Modelos.cd_usuarios()
                {
                    USUARIOS_NOMBRE = USUARIOS_NOMBRE,
                    USUARIOS_USUARIO = USUARIOS_USUARIO,
                    USUARIOS_CONTRASEÑA = Seguridad.Encriptar(USUARIOS_CONTRASEÑA),
                    USUARIOS_ROL = USUARIOS_ROL,
                });
            }
            return RedirectToAction("Inicio", "Menu");
        }

        private void Obj_Exception(object sender, ExceptionEventArgs e)
        {
            if (e.EntityValidationErrors != null)
            {
                throw new DbEntityValidationException(e.Message, e.EntityValidationErrors, e.InnerException) { Source = e.Source };

            }
  

        }
    }
}