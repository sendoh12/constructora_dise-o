using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace constructora_diseño.Controllers
{
    public class LoginController : Controller
    {
        Modelos.constructora_diseñoEntities contexto = new Modelos.constructora_diseñoEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Entrar(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Modelos.LoginViewModel data, string returnUrl)
        {
            ActionResult Result;
            string clave = Modelos.Seguridad.Encriptar(data.Password);
            Modelos.Repositorio<Modelos.cd_usuarios> Usuario = new Modelos.Repositorio<Modelos.cd_usuarios>(contexto);
            var User = Usuario.Retrieve(
                    x => x.USUARIOS_USUARIO == data.Usuario 
                    && x.USUARIOS_CONTRASEÑA == clave

                );

            if(User != null)
            {
                Result = SignInUser(User, data.Remember, returnUrl);
            }
            else
            {
                Result = View(data);
            }
            return Result;
        }

        private ActionResult SignInUser(cd_usuarios user, bool remember, string returnUrl)
        {
            throw new NotImplementedException();
        }
    }
}