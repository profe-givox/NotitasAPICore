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
                ad.sentencia = "insert into NotasTareas values(default,@titulo, @contenido, @estatus, @tipo,@fecha,@fechaModi,@fechaCum);SELECT LAST_INSERT_ID()";
                return  (ulong) ad.ejecutarSentencia(TIPOEJECUCIONSQL.ESCALAR) ;

            }
        }

        internal IEnumerable<NotaTarea> getAll()
        {
            throw new NotImplementedException();
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
