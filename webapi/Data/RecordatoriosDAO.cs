using MySqlConnector;
using webapi.Model;
using webapi.Util;

namespace webapi.Data
{
    public class RecordatoriosDAO
    {
        public RecordatoriosDAO() { }

        public ulong agregar(Recordatorios recordatorios)
        {
            var ad = new AccesoDatos();
            using (ad)
            {
                ad.parameters.Add(new MySqlConnector.MySqlParameter("@notitas_id", recordatorios.notitas_id));
                ad.parameters.Add(new MySqlConnector.MySqlParameter("@fecha_recordatorio", recordatorios.fecha_recordatorio));
                ad.sentencia = "insert into recordatorios (notitas_id, fecha_recordatorio) " +
                    "values(@notitas_id, @fecha_recordatorio);SELECT LAST_INSERT_ID();";
                return (ulong)ad.ejecutarSentencia(TIPOEJECUCIONSQL.ESCALAR);
            }
        }

    }
}
