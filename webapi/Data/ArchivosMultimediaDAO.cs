using MySqlConnector;
using webapi.Model;
using webapi.Util;

namespace webapi.Data
{
    public class ArchivosMultimediaDAO
    {
        public ulong Agregar(ArchivosMultimedia archivosMultimedia) {
            var ad = new AccesoDatos();
            using (ad) {
                ad.parameters.Add(new MySqlParameter("@notitas_id", archivosMultimedia.notitas_id));
                ad.parameters.Add(new MySqlParameter("@idArchivos", archivosMultimedia.idArchivos));
                ad.parameters.Add(new MySqlParameter("@url", archivosMultimedia.url));
                ad.parameters.Add(new MySqlParameter("@ruta", archivosMultimedia.ruta));
                ad.parameters.Add(new MySqlParameter("@descripcion", archivosMultimedia.descripcion));
                ad.parameters.Add(new MySqlParameter("@tipo", archivosMultimedia.tipo));
                ad.sentencia = "insert into Archivos values(default, @idArchivo, @url, @ruta, @descripcion, @tipo); SELECT LAST_INSERT_ID()";
                return (ulong)ad.ejecutarSentencia(TIPOEJECUCIONSQL.ESCALAR);
            }
        }

        public ulong Editar(ArchivosMultimedia multi)
        {
            var ad = new AccesoDatos();
            using (ad)
            {
                ad.parameters.Add(new MySqlParameter("@notitas_id", multi.notitas_id));
                ad.parameters.Add(new MySqlParameter("@idarchivos", multi.idArchivos));
                ad.parameters.Add(new MySqlParameter("@url", multi.url));
                ad.parameters.Add(new MySqlParameter("@ruta", multi.ruta));
                ad.parameters.Add(new MySqlParameter("@descripcion", multi.descripcion));
                ad.parameters.Add(new MySqlParameter("@tipo", multi.tipo));
                ad.sentencia = "UPDATE Archivos SET url = @url, ruta = @ruta, descripcion = @descripcion, tipo = @tipo " +
                                "WHERE idarchivos = @idarchivos";
                return (ulong)ad.ejecutarSentencia(TIPOEJECUCIONSQL.ESCALAR);
            }
        }

        public ArchivosMultimedia GetOneById(int idArchivo)
        {
            var ad = new AccesoDatos();
            ArchivosMultimedia archivoMultimedia = null;

            using (ad)
            {
                ad.parameters.Add(new MySqlParameter("@idArchivo", idArchivo));
                ad.sentencia = "SELECT * FROM Archivos WHERE idarchivo = @idArchivo";

                var reader = (MySqlDataReader)ad.ejecutarSentencia(TIPOEJECUCIONSQL.CONSULTA);

                while (reader.Read())
                {
                    archivoMultimedia = new ArchivosMultimedia
                    {
                        idArchivos = reader.GetUInt64("idarchivos"),
                        notitas_id = reader.GetInt32("notitas_id"),
                        url = reader.GetString("url"),
                        ruta = reader.GetString("ruta"),
                        descripcion = reader.GetString("descripcion"),
                        tipo = reader.GetInt32("tipo")
                    };
                }
            }

            return archivoMultimedia;
        }
    }
}
