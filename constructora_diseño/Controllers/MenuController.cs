using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelos;

namespace constructora_diseño.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Menu_principal()
        {
            return View();
        }

        public ActionResult Inicio()
        {
            using(Repositorio<cd_roles> obj = new Repositorio<cd_roles>())
            {
                obj.Exception += Obj_Exception;
                ViewBag.data = obj.Filter(x => true);
            }
            return View();
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