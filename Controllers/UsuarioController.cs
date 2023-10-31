using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NutriBank.Data.Dtos;
using NutriBank.Services;

namespace NutriBank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController:ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService cadastroService)
        {
            this._usuarioService = cadastroService;
        }

        [HttpPost("cadastro")]

        public async Task<IActionResult> CadastraUsurio(CreateUsuarioDto dto)
        {
            await _usuarioService.Cadastra(dto);
            return Ok("Usuário Cadastrado Com Sucesso!");
        }
        [AllowAnonymous]
        [HttpPost("login")]
        [Produces("application/json")]
        public async Task<string> LoginAsync(LoginUsuarioDto dto)
        {
            var token = await _usuarioService.Login(dto);
            return token;
        }
    }
}
