namespace JogoAdivinha.Models
{
    public class Dificuldade
    {
        public string Nome { get; set; }
        public int TotalTentativas { get; set; }

        public Dificuldade(string nome, int totalTentativas)
        {
            Nome = nome;
            TotalTentativas = totalTentativas;
        }
    }
}
