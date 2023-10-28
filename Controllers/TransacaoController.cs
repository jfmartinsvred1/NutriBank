using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NutriBank.Data.Dtos;
using NutriBank.Services;

namespace NutriBank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TransacaoController:ControllerBase
    {
        private TransacaoService _transacaoService;

        public TransacaoController(TransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        [HttpPost]

        public IActionResult NovaTransacao([FromBody] CreateTransacaoDto dto)
        {
            _transacaoService.TransacaoEntreContas(dto);
            return Ok("Transação Realizada Com Sucesso!");
        }
    }
}
