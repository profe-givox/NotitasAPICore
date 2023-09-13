    using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using webapi.Data;
using webapi.Model;

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
        //crea un public IActionResult que recibe el id de la nota para obtener los archivos multimedia


        [HttpGet("nota/{id}")]
        public IActionResult GetByNotaId(int id)
        {
            var multimediaList = new ArchivosMultimediaDAO().GetOneByIdNota(id);

            if (multimediaList == null)
            {
                return NotFound("No se encontraron archivos multimedia para la nota con el ID proporcionado.");
            }

            return Ok(multimediaList);
        }



        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var multimedia = new ArchivosMultimediaDAO().GetOneById(id);
            return multimedia == null ? NotFound() : Ok(multimedia);
        }

        // POST api/<ArchivosMultimediaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ArchivosMultimediaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ArchivosMultimedia updatedMultimedia)
        {
            if (updatedMultimedia == null)
            {
                return BadRequest("Los datos de multimedia actualizados son nulos.");
            }

            var existingMultimedia = new ArchivosMultimediaDAO().GetOneById(id);

            if (existingMultimedia == null)
            {
                return NotFound("Multimedia no encontrada.");
            }

            // Actualiza los campos en el objeto existingMultimedia con los datos actualizados
            existingMultimedia.url = updatedMultimedia.url;
            existingMultimedia.ruta = updatedMultimedia.ruta;
            existingMultimedia.descripcion = updatedMultimedia.descripcion;
            existingMultimedia.tipo = updatedMultimedia.tipo;

            // Llama al método Editar en tu DAO para guardar los cambios en la base de datos
            ulong resultadoEdicion = new ArchivosMultimediaDAO().Editar(existingMultimedia);

            if (resultadoEdicion > 0)
            {
                return Ok(existingMultimedia); // Devuelve la multimedia actualizada como respuesta si la edición tuvo éxito
            }
            else
            {
                // Maneja cualquier error que pueda ocurrir durante la edición
                return StatusCode(500, "Error interno del servidor al editar la multimedia.");
            }
        }


        // DELETE api/<ArchivosMultimediaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
