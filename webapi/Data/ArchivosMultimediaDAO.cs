using MySqlConnector;
using System.Data;
using webapi.Model;
using webapi.Util;


namespace webapi.Data
{
    public class ArchivosMultimediaDAO
    {

        public ArchivosMultimediaDAO() { }

   

        internal IEnumerable<ArchivosMultimedia> getAll()

        {
//regresa todos los datos de la tabla archiv de la base de datos
            var ad = new AccesoDatos();
            using (ad)
            {
                ad.sentencia = "select * from archivos";
                MySqlDataReader reader =
                    (MySqlDataReader)ad.ejecutarSentencia(TIPOEJECUCIONSQL.CONSULTA);
                List<ArchivosMultimedia> lista = new List<ArchivosMultimedia>();
                while (reader.Read())
                {
                    ArchivosMultimedia archivo = new ArchivosMultimedia();
                    archivo.idarchivos = reader.GetUInt64("idarchivos");
                    archivo.notitas_id = (int)reader.GetUInt64("notitas_id");

                    archivo.url = reader.GetString("url");
                    archivo.ruta = reader.GetString("ruta");
                         archivo.descripcion = reader.GetString("descripcion");
                    archivo.tipo = (int)reader.GetUInt64("tipo");

                    lista.Add(archivo);
                }
                return lista;
            }   
           
         
        }
    }



    }

