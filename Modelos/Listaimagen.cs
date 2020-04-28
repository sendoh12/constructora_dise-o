using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Listaimagen : Metodos
    {
        List<Imagenes> lista = new List<Imagenes>();
        public object Buscar(object obj)
        {
            throw new NotImplementedException();
        }

        public void Editar(object obj)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(object obj)
        {
            throw new NotImplementedException();
        }

        public void Insertar(object obj)
        {
            Imagenes img = (Imagenes)obj;
            String nombre = img.Imagen.FileName.Substring(0,img.Imagen.FileName.LastIndexOf("."));
            string ext = nombre.Substring(nombre.LastIndexOf(".")+1);
            String contentType = img.Imagen.ContentType;
            // imagen convertidad en bytes
            byte[] imagen = new byte[img.Imagen.InputStream.Length];
            img.Imagen.InputStream.Read(imagen,0,imagen.Length);
            SqlConnection cnx = new SqlConnection();
            try {
                cnx.Open();
                SqlCommand cmd = cnx.CreateCommand();
                cmd.CommandText =
                  "INSERT INTO Imagenes (nombre, imagen, extension, contentType) " +
                  "VALUES (@nombre, @imagen, @ext, @contentType)";
                cmd.Parameters.AddWithValue("@TITULO", nombre);
                cmd.Parameters.AddWithValue("@IMAGEN", imagen);
                cmd.Parameters.AddWithValue("@EXT", ext);
                cmd.Parameters.AddWithValue("@CONTENTTYPE", contentType);
                cmd.ExecuteNonQuery();

            }            
            catch(Exception e) {
            ///
            //alertad de la errro
            }
            finally
            {
                if (cnx != null)
                {
                    if (cnx.State == ConnectionState.Open)
                        cnx.Close();
                    cnx.Dispose();
                }
            }
        }

        public void mostrar(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
