using webapi.Model;
using MySqlConnector;
using webapi.Util;

namespace webapi.Data
{
    public class RecordatoriosDAO
    {
        //DESARROLLAR AQUI EL METODO ASIGNADO EN CLASE

        public static bool Eliminar(ulong id)
        {
            var ad = new AccesoDatos();
            using (ad)
            {
                try
                {
                    ad.sentencia = "DELETE FROM NotasTareas WHERE id=@id";
                    ad.parameters.Add(new MySqlParameter("@id", id));

                    int afectadas = (int)ad.ejecutarSentencia(TIPOEJECUCIONSQL.SENTENCIASQL);

                    // Verificar si se eliminó algún registro 
                    return afectadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar la nota/tarea: " + ex.Message);
                    return false;
                }
            }

        }
    }
}
