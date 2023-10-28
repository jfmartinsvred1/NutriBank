using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NutriBank.Data;
using NutriBank.Data.Dtos;
using NutriBank.Models;

namespace NutriBank.Services
{
    public class TransacaoService
    {
        private IMapper _mapper;
        private NutriBankContext _context;
        private UserManager<Usuario> _userManager;
        private ContaBancariaService _contaBancariaService;

        public TransacaoService(IMapper mapper, NutriBankContext context, UserManager<Usuario> userManager, ContaBancariaService contaBancariaService)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            _contaBancariaService = contaBancariaService;
        }

        public void TransacaoEntreContas(CreateTransacaoDto dto)
        {
            var contaDestinatario = _contaBancariaService.Get(dto.CpfDestinatario);
            var contaRemetente = _contaBancariaService.Get(dto.CpfRemetente);
            if(contaDestinatario == null || contaRemetente == null)
            {
                throw new ApplicationException("Conta iválida!");
            }
            Transacao transacao = new Transacao() { CpfDestinatario = dto.CpfDestinatario, CpfRemetente = dto.CpfRemetente, Valor = dto.Valor };
            _contaBancariaService.UpdateSaldo(dto.CpfRemetente, -dto.Valor);
            _contaBancariaService.UpdateSaldo(dto.CpfDestinatario, +dto.Valor);


            _context.Transacoes.Add(transacao);
            _context.SaveChanges();
        }
    }
}
