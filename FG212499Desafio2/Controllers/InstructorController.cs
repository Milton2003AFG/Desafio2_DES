using FG212499.BL.Interfaces;
using FG212499.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FG212499Desafio2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController(IInstructorService service) : ControllerBase
    {
        // GET: api/<InstructorController>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await service.GetAllAsync());

        // GET api/<InstructorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await service.GetByIdAsync(id);
            return res != null ? Ok(res) : NotFound();
        }

        // POST api/<InstructorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InstructorDto dto)
        {
            var id = await service.InsertAsync(dto);
            return CreatedAtAction(nameof(Get), new { id }, dto);
        }

        // PUT api/<InstructorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] InstructorDto dto)
        {
            dto.CodigoInstructor = id;
            var res = await service.UpdateAsync(dto);
            return res != null ? Ok(res) : NotFound();
        }

        // DELETE api/<InstructorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
        await service.DeleteAsync(id) ? Ok() : NotFound();
    }
}
