using MySqlConnector;

namespace webapi.Util
{

    public enum TIPOEJECUCIONSQL
    {
        CONSULTA,
        ESCALAR,
        SENTENCIASQL
    }

    public class AccesoDatos : IDisposable
    {



        private MySqlConnection conn;
        private MySqlCommand cmd;
        private bool disposedValue;
  
        public MySqlParameterCollection parameters { get; set; }
        public string sentencia { get; set; }

        public AccesoDatos()
        {
            conn = new MySqlConnection("Server=localhost;Root ID=user;Password=Root;Database=Notitas");
            cmd = new MySqlCommand();
            parameters =  cmd.Parameters;

        }

        public object ejecutarSentencia(TIPOEJECUCIONSQL  tipo) {

            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = sentencia;
            object result ; 
            switch (tipo)
            {   
               case TIPOEJECUCIONSQL.SENTENCIASQL:
                    result = cmd.ExecuteNonQuery();
                    break;

                case TIPOEJECUCIONSQL.CONSULTA:
                    result = cmd.ExecuteReader();
                    break;

                case TIPOEJECUCIONSQL.ESCALAR:
                    result = cmd.ExecuteScalar();
                    break;

                default:
                    result = null;
                    break;
            }
           
            parameters.Clear ();    
            return result;
        }                                                                   

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                    conn.Close();
                    
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~AccesoDatos()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
