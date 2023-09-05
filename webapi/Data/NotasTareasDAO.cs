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
                ad.parameters.Add(new MySqlConnector.MySqlParameter( "@titulo", notaTarea.tipo));
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
            throw new NotImplementedException();
        }
    }
}
