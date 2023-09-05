using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasTareasController : ControllerBase
    {
        // GET: api/<NotasTareasController>
        [HttpGet]
        public IEnumerable<NotaTarea> Get()
        {
            return new NotasTareasDAO().getAll();
        }

        // GET api/<NotasTareasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NotasTareasController>
        [HttpPost]
        public IActionResult Post([FromBody] NotaTarea value)
        {
            NotasTareasDAO dao = new NotasTareasDAO();
            value.id = dao.agregar(value);
            return CreatedAtAction(nameof(Get), new { id = value.id }, value);
                
        }

        // PUT api/<NotasTareasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotasTareasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
