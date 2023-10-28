using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NutriBank.Data;
using NutriBank.Data.Dtos;
using NutriBank.Models;

namespace NutriBank.Services
{
    public class ContaBancariaService
    {
        private IMapper _mapper;
        private NutriBankContext _context;
        private UserManager<Usuario> _userManager;

        public ContaBancariaService(IMapper mapper, NutriBankContext context, UserManager<Usuario> userManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }
        public void Create(CreateContaBancariaDto dtoBanco)
        {
           var user = _userManager.Users.FirstOrDefault(u => u.Cpf == dtoBanco.Cpf);
            if (user == null)
            {
                throw new ApplicationException("Cpf não cadastrado!");
            }

            var conta = _mapper.Map<ContaBancaria>(dtoBanco);
            
            conta.Id=user.Id;

            var buscaIgual=_context.ContasBancarias.FirstOrDefault(c=>c.Id==conta.Id);

            if(buscaIgual != null)
            {
                throw new ApplicationException("Usuário já tem uma conta cadastrada!");
            }

            _context.ContasBancarias.Add(conta);
            _context.SaveChanges();
        }
        public ReadContaBancariaDto Get(string cpf)
        {
            var conta = _mapper.Map<ReadContaBancariaDto>(_context.ContasBancarias.FirstOrDefault(c => c.Cpf == cpf));
            if (conta == null)
            {
                throw new ApplicationException("Não exite!");
            }
            return conta;
        }
        public void UpdateSaldo(string cpf, double valor)
        {
            var conta = _context.ContasBancarias.FirstOrDefault(c => c.Cpf == cpf);
            if (valor < 0 &&(conta.Saldo <= 0 || conta.Saldo < valor))
            {
                throw new ApplicationException("Saldo insuficiente!");
            } 
            conta.Saldo += valor;
            _context.SaveChanges();
        }
        
    }
}
