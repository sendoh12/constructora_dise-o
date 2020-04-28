using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using constructora_diseño;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            //Modelos.constructora_diseñoEntities contexto = new Modelos.constructora_diseñoEntities();
            //obj.Exception += Obj_Exception;
            //obj.Delete(obj.Retrieve(x => x.ROLES_ID == 2));

            using (Modelos.Repositorio<Modelos.cd_usuarios> dato = new Modelos.Repositorio<Modelos.cd_usuarios>())
                {
                dato.Exception += Obj_Exception;
                dato.Create(new Modelos.cd_usuarios()
                    {
                        USUARIOS_NOMBRE = "santos cervantes3",
                        USUARIOS_USUARIO = "santos3",
                        USUARIOS_CONTRASEÑA = Seguridad.Encriptar("sendoh123"),
                        USUARIOS_ROL = 1,
                    });

                    var listado = dato.Filter(x => true);
                    foreach (var item in listado)
                    {
                        Console.WriteLine(item.USUARIOS_NOMBRE);
                        Console.WriteLine(item.USUARIOS_CONTRASEÑA);
                    }
                }

            
            Console.WriteLine("Presione <enter> para salir");
            Console.ReadLine();
        }

        private static void Obj_Exception(object sender, Modelos.ExceptionEventArgs e)
        {
            Console.WriteLine(string.Format("Mensaje de error: {0}", e.Message));
            if (e.EntityValidationErrors != null)
            {
                foreach (var item in e.EntityValidationErrors)
                {
                    foreach (var error in item.ValidationErrors)
                    {
                        Console.WriteLine(
                            string.Format(
                                "Mensaje:{0}, PropertyName{1}", error.ErrorMessage,
                                error.PropertyName));
                    }
                }
            }
        }
    }
}
