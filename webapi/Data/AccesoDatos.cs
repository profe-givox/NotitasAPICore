using MySqlConnector;

namespace webapi.Data
{

    public class AccesoDatos : IDisposable
    {



        private MySqlConnection conn;
        private MySqlCommand cmd;
        private bool disposedValue;
  
        public MySqlParameterCollection parameters;    

        public AccesoDatos()
        {
            conn = new MySqlConnection("Server=myserver;User ID=mylogin;Password=mypass;Database=mydatabase");
            
        }

        public void ejecutarSentencia() {
            cmd = new MySqlCommand();
            
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
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
