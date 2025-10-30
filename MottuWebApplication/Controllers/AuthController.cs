using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MottuWebApplication.Application.Services;
using MottuWebApplication.Domain.Entities;
using System.Security.Claims;

namespace MottuWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Usuario model)
        {
            if (model.UserName == "usuario" && model.Password == "senha123")
            {
                var token = _tokenService.GenerateToken(model.UserName);
                return Ok(new { token });
            }
            return Unauthorized();
        }

        [HttpGet("dados-protegidos")]
        [Authorize]
        public IActionResult GetDadosProtegidos()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok($"Olá {username}! Você pode acessar os dados que foram protegidos do sistema, meus parabéns!");
        }

    }
}
