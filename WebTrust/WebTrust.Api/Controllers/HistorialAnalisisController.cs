using Microsoft.AspNetCore.Mvc;
using WebTrust.Domain.DTO.Historial;
using WebTrut.Application.Interfaces;

namespace WebTrust.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialAnalisisController : ControllerBase
    {
        private readonly IHistorialAnalisisService _service;

        public HistorialAnalisisController(IHistorialAnalisisService service)
        {
            _service = service;
        }

        [HttpGet("analisis/{idAnalisis}")]
        public async Task<IActionResult> GetByAnalisis(int idAnalisis)
        {
            var historial = await _service.GetByAnalisisAsync(idAnalisis);
            return Ok(historial);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HistorialAnalisisCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByAnalisis), new { idAnalisis = creado.IdAnalisis }, creado);
        }
    }
}
