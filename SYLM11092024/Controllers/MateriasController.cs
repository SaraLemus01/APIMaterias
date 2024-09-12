using Microsoft.AspNetCore.Mvc;
using SYLM11092024.Models;
using System.Collections.Generic;
using System.Linq;

namespace SYLM11092024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        // Static list to simulate a database
        static List<Materia> materias = new List<Materia>();

        // GET: api/<MateriasController>
        [HttpGet]
        public ActionResult<IEnumerable<Materia>> Get()
        {
            return Ok(materias);
        }

        // GET api/<MateriasController>/5
        [HttpGet("{id}")]
        public ActionResult<Materia> Get(int id)
        {
            var materia = materias.FirstOrDefault(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }
            return Ok(materia);
        }

        // POST api/<MateriasController>
        [HttpPost]
        public IActionResult Post([FromBody] Materia materia)
        {
            if (materia == null)
            {
                return BadRequest("Materia object is null");
            }

            if (materias.Any(m => m.Id == materia.Id))
            {
                return Conflict("A Materia with the same ID already exists.");
            }

            materias.Add(materia);
            return CreatedAtAction(nameof(Get), new { id = materia.Id }, materia);
        }

        // PUT api/<MateriasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Materia materia)
        {
            if (materia == null || id != materia.Id)
            {
                return BadRequest();
            }

            var existingMateria = materias.FirstOrDefault(m => m.Id == id);
            if (existingMateria == null)
            {
                return NotFound();
            }

            existingMateria.Name = materia.Name;
            existingMateria.Description = materia.Description;
            return NoContent();
        }

        // DELETE api/<MateriasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingMateria = materias.FirstOrDefault(m => m.Id == id);
            if (existingMateria == null)
            {
                return NotFound();
            }

            materias.Remove(existingMateria);
            return NoContent();
        }
    }
}
