
using Microsoft.IdentityModel.Tokens;
using NutriBank.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NutriBank.Services
{
    public class TokenService
    {
        public string GenerateToken(Usuario usuario)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("cpf",usuario.Cpf.ToString()),
                new Claim("dataNascimento",usuario.DataNascimento.ToString()),
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HSUBFSUF(*F8YfbbfdIFBUFDBHS()*F8fYSBFYB"));

            var signInCredentials = new SigningCredentials(chave,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires:DateTime.Now.AddMinutes(30),
                claims:claims,
                signingCredentials:signInCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
