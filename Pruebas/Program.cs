using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Modelos.Repositorio<Modelos.cd_roles> obj = new Modelos.Repositorio<Modelos.cd_roles>())
            {
                obj.Exception += Obj_Exception;
                obj.Delete(obj.Retrieve(x => x.ROLES_ID == 2));

                var listado = obj.Filter(x => true);
                foreach (var item in listado)
                {
                    Console.WriteLine(item.ROLES_NOMBRES);
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
