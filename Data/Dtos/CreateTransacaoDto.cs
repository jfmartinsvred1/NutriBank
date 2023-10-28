using System.ComponentModel.DataAnnotations;

namespace NutriBank.Data.Dtos
{
    public class CreateTransacaoDto
    {
        public double Valor { get; set; }
        [Required]
        public string CpfDestinatario { get; set; }
        [Required]
        public string CpfRemetente { get; set; }
    }
}
