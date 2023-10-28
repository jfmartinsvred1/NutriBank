using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NutriBank.Data.Dtos;
using NutriBank.Services;

namespace NutriBank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaBancariaController:ControllerBase
    {
        private ContaBancariaService _contaBancariaService;

        public ContaBancariaController(ContaBancariaService contaBancariaService)
        {
            _contaBancariaService = contaBancariaService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateContaBancariaDto dto)
        {
            _contaBancariaService.Create(dto);
            return Ok("Conta Criada Com Sucesso!");
        }
        [HttpGet("{cpf}")]
        [Authorize]
        public IActionResult Get(string cpf)
        {
            return Ok(_contaBancariaService.Get(cpf));
        }
    }
}
