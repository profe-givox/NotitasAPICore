namespace webapi.Model
{
    public class NotaTarea
    {
      
       
        public ulong id { get; set; }
        public string titulo { get; set; }
        public string contenido { get; set; }
        public int? estatus { get; set; } 
        public int tipo { get; set; }

        public DateTime? fecha { get; set; } 
        public DateTime? fechaModi { get; set; } 
        public DateTime? fechaCum { get; set; } 
    
    }

}
