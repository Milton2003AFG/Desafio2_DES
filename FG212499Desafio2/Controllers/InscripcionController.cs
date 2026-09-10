using FG212499.BL.Interfaces;
using FG212499.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FG212499Desafio2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionController(IInscripcionService service) : ControllerBase
    {
        // GET: api/<InscripcionController>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await service.GetAllAsync());

        // GET api/<InscripcionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await service.GetByIdAsync(id);
            return res != null ? Ok(res) : NotFound();
        }

        // POST api/<InscripcionController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InscripcionDto dto)
        {
            try
            {
                var id = await service.InsertAsync(dto);
                return CreatedAtAction(nameof(Get), new { id }, dto);
            }
            catch (InvalidOperationException ex)
            {
                // Error de duplicidad
                return Conflict(new { mensaje = ex.Message });
            }
            catch (ArgumentException ex)
            {
                // Error de validación de claves foráneas
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // PUT api/<InscripcionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] InscripcionDto dto)
        {
            dto.CodigoInscripcion = id;
            var res = await service.UpdateAsync(dto);
            return res != null ? Ok(res) : NotFound();
        }

        // DELETE api/<InscripcionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
        await service.DeleteAsync(id) ? Ok() : NotFound();
    }
}
