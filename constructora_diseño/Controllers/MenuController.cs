using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }
    }
}