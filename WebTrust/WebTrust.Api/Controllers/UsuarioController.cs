using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebTrust.Domain.DTO.UsuarioDTO;
using WebTrust.Domain.Entities;
using WebTrut.Application.Interfaces;


namespace WebTrut.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // ✅ GET: api/usuarios
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioService.ObtenerUsuariosAsync();
            return Ok(usuarios);
        }

        // ✅ GET: api/usuarios/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _usuarioService.ObtenerPorIdAsync(id);
            if (usuario == null)
                return NotFound(new { message = "Usuario no encontrado" });

            return Ok(usuario);
        }

        // ✅ POST: api/usuarios
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _usuarioService.RegistrarAsync(dto);
            return Ok(new { message = "Usuario registrado correctamente" });
        }

        // ✅ PUT: api/usuarios/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuarioActualizado = await _usuarioService.ActualizarAsync(id, dto);

            if (usuarioActualizado == null)
                return NotFound(new { message = "Usuario no encontrado" });

            return Ok(new { message = "Usuario actualizado correctamente", usuario = usuarioActualizado });
        }

        // ✅ DELETE: api/usuarios/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _usuarioService.EliminarAsync(id);
            if (!deleted)
                return NotFound(new { message = "Usuario no encontrado" });

            return Ok(new { message = "Usuario eliminado (inactivado) correctamente" });
        }
    }
}
