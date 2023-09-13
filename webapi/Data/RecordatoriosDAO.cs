using webapi.Model;
using MySqlConnector;
using webapi.Util;

namespace webapi.Data
{
    public class RecordatoriosDAO
    {
        //DESARROLLAR AQUI EL METODO ASIGNADO EN CLASE

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
                        idRecordatorios = reader.GetUInt64("idRecordatorios")
                       // notitas_id = reader.GetInt32("notitas_id"),
                       // fecha_recordatorio = reader.GetString("fecha_recordatorio"),
                    };
                }
            }

            return recordatorios;
        }
















        public ulong agregar(NotaTarea notaTarea)
        {
            var ad = new AccesoDatos();
            using (ad)
            {
                ad.parameters.Add(new MySqlConnector.MySqlParameter("@titulo", notaTarea.titulo));
                ad.parameters.Add(new MySqlConnector.MySqlParameter("@contenido", notaTarea.contenido));
                ad.parameters.Add(new MySqlConnector.MySqlParameter("@estatus", notaTarea.estatus));
                ad.parameters.Add(new MySqlConnector.MySqlParameter("@tipo", notaTarea.tipo));
                ad.sentencia = "insert into NotasTareas (titulo, contenido,estatus, tipo) " +
                    "values(@titulo, @contenido, @estatus, @tipo);SELECT LAST_INSERT_ID();";
                return (ulong)ad.ejecutarSentencia(TIPOEJECUCIONSQL.ESCALAR);

            }
        }







    }
}
