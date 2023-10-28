using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutriBank.Models
{
    public class ContaBancaria
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public virtual Usuario Usuario { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Saldo { get; set; } = 0;
        public string Cpf { get; set; }
        public ICollection<Transacao> Transacoes { get; set; }
    }
}
