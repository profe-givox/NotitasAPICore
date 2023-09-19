using MySqlConnector;
using webapi.Model;
using webapi.Util;

namespace webapi.Data
{
    public class NotasTareasDAO
    {
        public NotasTareasDAO() { }

        public ulong agregar(NotaTarea notaTarea) {
            var ad = new AccesoDatos();
            using (ad ) {
                ad.parameters.Add(new MySqlConnector.MySqlParameter( "@titulo", notaTarea.titulo));
                ad.parameters.Add(new MySqlConnector.MySqlParameter("@contenido", notaTarea.contenido));
                ad.parameters.Add(new MySqlConnector.MySqlParameter("@estatus", notaTarea.estatus));
                ad.parameters.Add(new MySqlConnector.MySqlParameter("@tipo", notaTarea.tipo));
                ad.parameters.Add(new MySqlConnector.MySqlParameter("@fecha", notaTarea.fecha));
                ad.parameters.Add(new MySqlConnector.MySqlParameter("@fechaModi", notaTarea.fechaModi));
                ad.parameters.Add(new MySqlConnector.MySqlParameter("@fechaCum", notaTarea.fechaCum));
                ad.sentencia = "insert into NotasTareas values(default,@titulo, @contenido, @estatus, @tipo,@fecha,@fechaModi,@fechaCum);SELECT LAST_INSERT_ID()";
                return  (ulong) ad.ejecutarSentencia(TIPOEJECUCIONSQL.ESCALAR) ;
            }
        }
        //GEt All
        internal IEnumerable<NotaTarea> getAll()
        {
            List<NotaTarea> notasTareas = new List<NotaTarea>();
            var ad = new AccesoDatos();

            using (ad)
            {
                ad.sentencia = "SELECT * FROM NotasTareas";
                MySqlDataReader reader = (MySqlDataReader)ad.ejecutarSentencia(TIPOEJECUCIONSQL.CONSULTA);

                while (reader.Read())
                {
                    NotaTarea nota = new NotaTarea
                    {
                        
                        id = reader.GetUInt64("id"),
                        titulo = reader.IsDBNull(reader.GetOrdinal("titulo")) ? string.Empty : reader.GetString("titulo"),
                        contenido = reader.IsDBNull(reader.GetOrdinal("contenido")) ? null : reader.GetString("contenido"),
                        estatus = reader.IsDBNull(reader.GetOrdinal("estatus")) ? (int?)null : reader.GetInt32("estatus"),
                        tipo = reader.IsDBNull(reader.GetOrdinal("tipo")) ? 1 : reader.GetInt32("tipo"),
                        fecha = reader.IsDBNull(reader.GetOrdinal("fecha")) ? (DateTime?)null : reader.GetDateTime("fecha"),
                        fechaModi = reader.IsDBNull(reader.GetOrdinal("fechaModi")) ? (DateTime?)null : reader.GetDateTime("fechaModi"),
                        fechaCum = reader.IsDBNull(reader.GetOrdinal("fechaCum")) ? (DateTime?)null : reader.GetDateTime("fechaCum")
                    };
                    notasTareas.Add(nota);
                }
            }

            return notasTareas;
        }

        public NotaTarea getOneById(int id)
        {
            var ad = new AccesoDatos();
            NotaTarea nota = null;
            using (ad )
            {
                ad.sentencia = "SELECT * from NotasTareas WHERE id=@id";
                ad.parameters.Add(new MySqlParameter("@id", id));
                MySqlDataReader reader =
                    (MySqlDataReader)ad.ejecutarSentencia(TIPOEJECUCIONSQL.CONSULTA);
                
                while (reader.Read())
                {
                    nota = new NotaTarea();
                    nota.id = reader.GetUInt64("id");
                    nota.titulo = reader.GetString("titulo");
                    nota.contenido = reader.GetString("contenido");
                    nota.estatus = reader.GetInt32("estatus");
                    nota.tipo = reader.GetInt32("tipo");

                    if (!reader.IsDBNull(reader.GetOrdinal("fecha")))
                    {
                        nota.fecha = reader.GetDateTime(reader.GetOrdinal("fecha"));
                    }
                    else
                    {
                        nota.fecha = DateTime.MinValue; 
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("fechaModi")))
                    {
                        nota.fechaModi = reader.GetDateTime(reader.GetOrdinal("fechaModi"));
                    }
                    else
                    {
                        nota.fechaModi = DateTime.MinValue; 
                    }

                    if (!reader.IsDBNull(reader.GetOrdinal("fechaCum")))
                    {
                        nota.fechaCum = reader.GetDateTime(reader.GetOrdinal("fechaCum"));
                    }
                    else
                    {
                        nota.fechaCum = DateTime.MinValue;
                    }
                }

            }

            return nota;
        }
    }
}
