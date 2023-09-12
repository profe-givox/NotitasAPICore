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
                ad.sentencia = "insert into NotasTareas (titulo, contenido,estatus, tipo) " +
                    "values(@titulo, @contenido, @estatus, @tipo);SELECT LAST_INSERT_ID();";
                return  (ulong) ad.ejecutarSentencia(TIPOEJECUCIONSQL.ESCALAR) ;

            }
        }

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
                        estatus = reader.IsDBNull(reader.GetOrdinal("estatus")) ? 0 : reader.GetInt32("estatus"),
                        tipo = reader.IsDBNull(reader.GetOrdinal("tipo")) ? 1 : reader.GetInt32("tipo")
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
                ad.sentencia = "select * from NotasTareas where id=@id";
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
                }

            }

            return nota;
        }
    }
}
