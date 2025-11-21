using Microsoft.AspNetCore.Mvc;
using WebTrust.Domain.DTO.AnalisisDTO;
using WebTrut.Application.Interfaces;

namespace WebTrust.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalisisController : ControllerBase
    {
        private readonly IAnalisisService _analisisService;

        public AnalisisController(IAnalisisService analisisService)
        {
            _analisisService = analisisService;
        }

        // POST: api/analisis
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] AnalisisCreateDto dto)
        {
            var analisis = await _analisisService.CrearAsync(dto);
            return Ok(new { mensaje = "Análisis creado correctamente", analisis });
        }

        // GET: api/analisis
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var lista = await _analisisService.ObtenerTodosAsync();
            return Ok(lista);
        }

        // GET: api/analisis/usuario/1
        [HttpGet("usuario/{idUsuario:int}")]
        public async Task<IActionResult> ObtenerPorUsuario(int idUsuario)
        {
            var lista = await _analisisService.ObtenerPorUsuarioAsync(idUsuario);
            return Ok(lista);
        }

        // GET: api/analisis/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var analisis = await _analisisService.ObtenerPorIdAsync(id);
            if (analisis == null)
                return NotFound("Análisis no encontrado");

            return Ok(analisis);
        }

        // DELETE: api/analisis/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool eliminado = await _analisisService.EliminarAsync(id);
            if (!eliminado)
                return NotFound("No se pudo eliminar el análisis");

            return Ok(new { mensaje = "Análisis eliminado correctamente" });
        }
    }
}
