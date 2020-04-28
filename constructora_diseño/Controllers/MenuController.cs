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
        // GET: Menu
        public ActionResult Menu_principal()
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult Inicio()
        {
            using (Repositorio<cd_roles> obj = new Repositorio<cd_roles>())
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
            using(Repositorio<cd_usuarios> obj = new Repositorio<cd_usuarios>())
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

        [HttpGet]
        public ActionResult Cargarimagenes()
        {
            return View();
        }

        [HttpPost]
        public void ingresar() 
        {
            try {
                Imagenes img = new Imagenes();
                Listaimagen list = new Listaimagen();
                HttpPostedFileBase archivo = Request.Files[0];
                 //img.Titulo = (archivo.FileName).ToLower();
                if (archivo.ContentLength > 0)
                {
                    string ext = archivo.FileName;
                    img.Titulo = ext.Substring(ext.LastIndexOf(".") + 1).ToLower();
                    string[] formatos = new string[] { "jpg", "jpeg", "bmp", "png", "gif" };
                    if (Array.IndexOf(formatos, img.Titulo) < 0)
                    {
                        //MensajeError("Formato de imagen inválido.");
                        //alertas avisar si la imagen esta guardado con los formatos o esta equibocado mesaje de 
                        //error
                    }
                    else {
                        ///guardamos
                        ///
                        img.Imagen = archivo;
                        //guardamos la imagen en la base de datos
                        list.Insertar(img);
                        
                    }

                }
                //return View();
            } catch (Exception ex) {
                Console.WriteLine(ex);
            
            }
        }
    }
}