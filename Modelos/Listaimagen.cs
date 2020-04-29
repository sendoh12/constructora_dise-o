using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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
            String titulo = img.Imagen.FileName.Substring(0,img.Imagen.FileName.LastIndexOf("."));
            string ext = titulo.Substring(titulo.LastIndexOf(".")+1);
            String contentType = img.Imagen.ContentType;
            // imagen convertidad en bytes
            byte[] imagen = new byte[img.Imagen.InputStream.Length];
            img.Imagen.InputStream.Read(imagen,0,imagen.Length);
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand()) 
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT imagenes(IMAGENES,TITULO,EXT,CONTENTTYPE)VALUES(@IMGENES,@TITULO,@EXT,@CONTENTTYPE)";
                    cmd.Parameters.Add("@IMAGENES", SqlDbType.Binary).Value = imagen;
                    cmd.Parameters.Add("@TITULO", SqlDbType.VarChar).Value = titulo;
                    cmd.Parameters.Add("@EXT", SqlDbType.VarChar).Value = ext;
                    cmd.Parameters.Add("@CONTENTTYPE", SqlDbType.VarChar).Value = contentType;
                    int files_afectadas = cmd.ExecuteNonQuery();
                    Console.WriteLine("filas afectadas"+files_afectadas);
                    Console.ReadKey();
                }
            
            }
                
                /*cnx.Open();
                SqlCommand cmd = cnx.CreateCommand();
                cmd.CommandText ="INSERT INTO imagenes (TITULO, IMAGEN, EXT, CONTENTTYPE) " +
                  "VALUES (@TITULO, @IMAGEN, @EXT, @CONTENTTYPE)";
                cmd.Parameters.AddWithValue("@TITULO", titulo);
                cmd.Parameters.AddWithValue("@IMAGEN", imagen);
                cmd.Parameters.AddWithValue("@EXT", ext);
                cmd.Parameters.AddWithValue("@CONTENTTYPE", contentType);
                cmd.ExecuteNonQuery();
                */
            
        }

        public void mostrar(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
