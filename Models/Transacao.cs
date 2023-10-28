using System.ComponentModel.DataAnnotations;

namespace NutriBank.Models
{
    public class Transacao
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public string CpfDestinatario { get; set; }
        [Required]  
        public string CpfRemetente { get; set; }
        [Required]
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
