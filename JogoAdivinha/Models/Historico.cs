using System.ComponentModel.DataAnnotations;

namespace JogoAdivinha.Models
{
    public class Historico
    {
        public int COD_JOGADOR { get; set; }
        public int NUM_TENTATIVA { get; set; }
        [Key]
        public DateTime Tentativa { get; set; }
        public string? RESULTADO { get; set; }

    }
}
