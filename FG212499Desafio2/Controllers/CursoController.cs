using System.Text.Json;
using FG212499.BL.Interfaces;
using FG212499.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FG212499Desafio2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController(ICursoService service, IConnectionMultiplexer? redis = null) : ControllerBase
    {
        // GET: api/<CursoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Consulta desde Redis si está disponible
            if (redis != null)
            {
                var db = redis.GetDatabase();
                var cache = await db.StringGetAsync("cursos_list");
                if (!cache.IsNullOrEmpty)
                {
                    var cachedList = JsonSerializer.Deserialize<List<CursoDto>>(cache!);
                    return Ok(cachedList);
                }
            }

            var list = await service.GetAllAsync();

            if (redis != null)
            {
                var db = redis.GetDatabase();
                await db.StringSetAsync("cursos_list", JsonSerializer.Serialize(list), TimeSpan.FromMinutes(10));
            }

            return Ok(list);
        }

        // GET api/<CursoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await service.GetByIdAsync(id);
            return res != null ? Ok(res) : NotFound();
        }

        // POST api/<CursoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CursoDto dto)
        {
            try
            {
                var id = await service.InsertAsync(dto);
                // Invalidación de caché en Redis
                if (redis != null) await redis.GetDatabase().KeyDeleteAsync("cursos_list");
                return CreatedAtAction(nameof(Get), new { id }, dto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // PUT api/<CursoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CursoDto dto)
        {
            try
            {
                dto.CodigoCurso = id;
                var res = await service.UpdateAsync(dto);
                if (redis != null) await redis.GetDatabase().KeyDeleteAsync("cursos_list");
                return res != null ? Ok(res) : NotFound();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // DELETE api/<CursoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await service.DeleteAsync(id);
            if (ok && redis != null) await redis.GetDatabase().KeyDeleteAsync("cursos_list");
            return ok ? Ok() : NotFound();
        }
    }
}
