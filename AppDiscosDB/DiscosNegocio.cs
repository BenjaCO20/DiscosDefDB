using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
namespace AppDiscosDB
{
    internal class DiscosNegocio
    {
        
     public List<Disco> listar() 
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Disco> listado = new List<Disco>();

            
            try
            {
                conexion.ConnectionString = "server=(localdb)\\MSSQLLocalDB; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa,E.Descripcion Estilo, T.Descripcion TipoEdicion\r\nfrom DISCOS D, Estilos E, TIPOSEDICION T where E.Id = D.IdEstilo and D.IdTipoEdicion = T.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Disco disco = new Disco();
                    disco.Titulo = (string)lector["Titulo"];
                    disco.FechaDeLanzamiento = (DateTime)lector["FechaLanzamiento"];
                    disco.CantCanciones = (Int32)lector["CantidadCanciones"];
                    disco.UrlImagen = (string)lector["UrlImagenTapa"];

                    disco.TipoEdicion = new Elemento();
                    disco.TipoEdicion.Descripcion = (string)lector["TipoEdicion"];

                    disco.Estilo = new Elemento();
                    disco.Estilo.Descripcion = (string)lector["Estilo"];
                    listado.Add(disco);
                 }

                conexion.Close();
                return listado;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    

}
