using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NutriBank.Models
{
    public class Usuario:IdentityUser<Guid>
    {
        [MaxLength(11)]
        public string Cpf { get; set; }
        public ContaBancaria ContaBancaria { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
