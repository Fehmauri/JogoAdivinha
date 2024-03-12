using static JogoAdivinha.Controllers.JogoController;

namespace JogoAdivinha.Models
{
    public class NumeroJogadorDif
    {

        public int Num { get; set; }
        public TipoJogador tipoJogador { get; set; }
        public string Dificuldade { get; set; }
    }
}
