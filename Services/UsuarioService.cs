using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NutriBank.Data;
using NutriBank.Data.Dtos;
using NutriBank.Models;

namespace NutriBank.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private NutriBankContext _context;
        private SignInManager<Usuario> _signInManager;
        private UserManager<Usuario> _userManager;
        private TokenService _tokenService;

        public UsuarioService(IMapper mapper, NutriBankContext context, 
            SignInManager<Usuario> signInManager, UserManager<Usuario> userManager,
            TokenService tokenService)
        {
            _mapper = mapper;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task Cadastra(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);
            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException
                ("Falha ao cadastrar usuário!");
            }
        }
        internal async Task<string> Login(LoginUsuarioDto dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuario não autenticado!");
            }

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(usuario);

            return token;
        }
        internal string GetCpf(string username)
        {
            var user= _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName ==username.ToUpper());

            return user.Cpf;
        }

    }
}
