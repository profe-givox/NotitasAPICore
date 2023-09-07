    using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivosMultimediaController : ControllerBase
    {
        //DESARROLLAR AQUI EL METODO ASIGNADO EN CLASE
        //Los ejemplos de abajo son la base     para desarrollar el que te fue asignado en clase
        //Aqui se se invoca el DAO. Recuerda que debes desarrollar el metodo en el DAO  

        // GET: api/<ArchivosMultimediaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ArchivosMultimediaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ArchivosMultimediaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ArchivosMultimediaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArchivosMultimediaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
