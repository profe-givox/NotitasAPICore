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
        public  IActionResult Get(int id)
        {
            var notatarea  =  new NotasTareasDAO().getOneById(id);
            return notatarea == null ?
            NotFound() : Ok(notatarea);
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
        public void Delete(int id, [FromBody] NotaTarea value)
        {

            if (value == null)
            {
                return BadRequest("No hay datos a Eliminar.");
            }

            var existingRec = new NotasTareasDAO().GetOneById(idid);

            if (existingRec == null)
            {
                return NotFound("No se encontro la Nota/Tarea.");
            }

            existingRec.fecha = value.fecha;

            int resultadoEdicion = new NotasTareasDAO().Eliminar(idid);

            if (resultadoEdicion > 0)
            {
                return Ok(existingRec);
            }
            else
            {
                return StatusCode(500, "Error al actualizar.");
            }
        }
    }
}
