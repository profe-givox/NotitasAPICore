using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using webapi.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordatoriosController : ControllerBase
    {
        //DESARROLLAR AQUI EL METODO ASIGNADO EN CLASE
        //Los ejemplos de abajo son la base     para desarrollar el que te fue asignado en clase
        //Aqui se se invoca el DAO. Recuerda que debes desarrollar el metodo en el DAO  

        // GET: api/<RecordatoriosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RecordatoriosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RecordatoriosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RecordatoriosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecordatoriosController>/5
        [HttpDelete("{id}")]

        public void Delete(int id)
        {

            // Llama al método Eliminar de tu NotasTareasDAO
            bool eliminacionExitosa = RecordatoriosDAO.Eliminar((ulong)id);

        }

    }
    
}
