using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTrust.Domain.DTO.UsuarioDTO;
using WebTrut.Application.Service;

namespace WebTrust.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService loginService;

        public LoginController (LoginService login)
        
        {
        
        
          loginService = login; 
        
        
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest(new { message = "Los datos de inicio de sesión son requeridos." });

                if (string.IsNullOrWhiteSpace(dto.Email))
                    return BadRequest(new { message = "El correo electrónico es obligatorio." });

                if (string.IsNullOrWhiteSpace(dto.Password))
                    return BadRequest(new { message = "La contraseña es obligatoria." });

                var usuario = await loginService.LoginAsync(dto.Email, dto.Password);

                return Ok(new
                {
                    mensaje = $"¡Bienvenido, {usuario.Nombre}!",

                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }







    }
}
