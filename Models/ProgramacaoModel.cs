using System.ComponentModel.DataAnnotations;

namespace Microondas.Models
{
    public class ProgramacaoModel
    {
        [Key]
        public int idProgramacao { get; set; }
        public string nomeDaProgramacao { get; set; } = string.Empty;
        public string alimento { get; set; } = string.Empty;
        public int tempo { get; set; }
        public int potencia { get; set; }
        public string stringDeAquecimento { get; set; } = string.Empty;
        public string instrucoesComplementares { get; set; } = string.Empty;
    }
}
