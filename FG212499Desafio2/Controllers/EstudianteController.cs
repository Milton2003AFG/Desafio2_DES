using FG212499.BL.Interfaces;
using FG212499.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FG212499Desafio2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController(IEstudianteService service) : ControllerBase
    {
        // GET: api/<EstudianteController>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await service.GetAllAsync());

        // GET api/<EstudianteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await service.GetByIdAsync(id);
            return res != null ? Ok(res) : NotFound();
        }

        // POST api/<EstudianteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EstudianteDto dto)
        {
            var id = await service.InsertAsync(dto);
            return CreatedAtAction(nameof(Get), new { id }, dto);
        }

        // PUT api/<EstudianteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EstudianteDto dto)
        {
            dto.CodigoEstudiante = id;
            var res = await service.UpdateAsync(dto);
            return res != null ? Ok(res) : NotFound();
        }

        // DELETE api/<EstudianteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
        await service.DeleteAsync(id) ? Ok() : NotFound();
    }
}
