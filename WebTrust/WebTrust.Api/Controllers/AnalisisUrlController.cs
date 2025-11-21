using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTrut.Application.DTOs;
using WebTrut.Application.Interfaces;

namespace WebTrust.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalisisUrlController : ControllerBase
    {


        private readonly IAnalisisUrlService _analisisService;

        public AnalisisUrlController(IAnalisisUrlService analisisService)
        {
            _analisisService = analisisService;
        }

        [HttpPost("analizar")]
        public async Task<IActionResult> AnalizarPagina([FromBody] AnalisisUrlDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Url))
                return BadRequest("Debe proporcionar una URL.");

            var resultado = await _analisisService.AnalizarSitioWebAsync(dto.Url);
            return Ok(resultado);
        }

    }
}
