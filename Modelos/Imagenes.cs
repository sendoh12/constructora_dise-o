using MetodosDeExtension;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
namespace Modelos
{
    public class Imagenes
    {
        public string Titulo { get; set; }
        public HttpPostedFileBase  Imagen { get; set; }
        /*constructores */
        public Imagenes()
        {
        }

        public Imagenes(string titulo, HttpPostedFileBase imagen)
        {
            Titulo = titulo;
            Imagen = imagen;
        }

        public Imagenes(HttpPostedFileBase imagen)
        {
            Imagen = imagen;
        }
    }
}
