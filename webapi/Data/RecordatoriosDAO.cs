using MySqlConnector;
using webapi.Model;

using webapi.Util;

namespace webapi.Data
{
    public class RecordatoriosDAO
    {
        public  int Eliminar(int  idreordatorio)
        {
            var ad = new AccesoDatos();
            Recordatorios recordatorios = null;

            using (ad)
            {
                          
                    ad.parameters.Add(new MySqlParameter("@idRecordatorios", idreordatorio));
                    //ad.parameters.Add(new MySqlParameter("@notitas_id", delete.notitas_id));
                    //ad.parameters.Add(new MySqlParameter("@fecha_recordatorio", delete.fecha_recordatorio));
                    ad.sentencia = "DELETE FROM recordatorios WHERE idrecordatorios =@idrecordatorios";


                //ad.sentencia = "DELETE FROM Recordatorios WHERE id=@idrecordatorio";
                //ad.parameters.Add(new MySqlConnector.MySqlParameter("@idNota", id));

                // int afectadas = (int)ad.ejecutarSentencia(TIPOEJECUCIONSQL.SENTENCIASQL);

                // Verificar si se eliminó algún registro 
                return (int)ad.ejecutarSentencia(TIPOEJECUCIONSQL.SENTENCIASQL);
                
            }
        }

        public RecordatoriosDAO() { }
        public ulong Agregar(Recordatorios rec)
        {
            var ad = new AccesoDatos();
            using (ad)
            {
                ad.parameters.Add(new MySqlConnector.MySqlParameter("@notitas_id", rec.notitas_id));
                ad.parameters.Add(new MySqlConnector.MySqlParameter("@fecha_recordatorio", rec.fecha_recordatorio));
                ad.sentencia = "insert into recordatorios (notitas_id, fecha_recordatorio) " +
                    "values(@notitas_id, @fecha_recordatorio);SELECT LAST_INSERT_ID();";
                return (ulong)ad.ejecutarSentencia(TIPOEJECUCIONSQL.ESCALAR);
            }
        }

        public ulong Editar(Recordatorios rec)
        {
            var ad = new AccesoDatos();
            using (ad)
            {
                ad.parameters.Add(new MySqlParameter("@idRecordatorios", rec.idRecordatorios));
                ad.parameters.Add(new MySqlParameter("@notitas_id", rec.notitas_id));
                ad.parameters.Add(new MySqlParameter("@fecha_recordatorio", rec.fecha_recordatorio));
                ad.sentencia = "UPDATE recordatorios " +
                                "SET fecha_recordatorio = @fecha_recordatorio" +
                                "WHERE idRecordatorios = @idRecordatorios";
                return (ulong)ad.ejecutarSentencia(TIPOEJECUCIONSQL.SENTENCIASQL);
            }
        }

        public Recordatorios GetOneById(int idRecordatorio)
        {
            var ad = new AccesoDatos();
            Recordatorios recordatorios = null;

            using (ad)
            {
                ad.parameters.Add(new MySqlParameter("@idRecordatorios", idRecordatorio));
                ad.sentencia = "SELECT * FROM Recordatorios WHERE idRecordatorios = @idRecordatorios";

                var reader = (MySqlDataReader)ad.ejecutarSentencia(TIPOEJECUCIONSQL.CONSULTA);

                while (reader.Read())
                {
                    recordatorios = new Recordatorios
                    {
                        
                       // notitas_id = reader.GetInt32("notitas_id"),
                       // fecha_recordatorio = reader.GetString("fecha_recordatorio"),
                        idRecordatorios = reader.GetUInt64("idRecordatorios"),
                        notitas_id = reader.GetInt32("notitas_id"),
                        fecha_recordatorio = reader.GetString("fecha_recordatorio"),
                    };
                }
            }

            return recordatorios;
        }
      
    }
}
