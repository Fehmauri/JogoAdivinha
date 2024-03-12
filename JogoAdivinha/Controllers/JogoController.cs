using JogoAdivinha.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace JogoAdivinha.Controllers
{
    public class JogoController : Controller
    {
        private readonly ILogger<JogoController> _logger;
        public Dictionary<string, Dificuldade> Dificuldades { get; }
        private readonly Contexto _contexto;
        public JogoController(ILogger<JogoController> logger, Contexto contexto)
        {
            _logger = logger;
            _contexto = contexto;
            Dificuldades = new Dictionary<string, Dificuldade>();
            Dificuldades.Add("Fácil", new Dificuldade("Fácil", 7));
            Dificuldades.Add("Médio", new Dificuldade("Médio", 5));
            Dificuldades.Add("Difícil", new Dificuldade("Difícil", 3));
        }

        public IActionResult Index()
        {
            return View();
        }

        public enum TipoJogador
        {
            Jogador,
            Maquina
        }
        public enum Resultado
        {
            SUCCESS,
            WRONG
        }

        public NumeroJogadorDif IniciarJogo(string dif)
        {

            var info = new NumeroJogadorDif();
            TipoJogador tipoJogador = SelecionarJogador();
            var numeroSecreto = GerarNumeroSecreto();

            info.tipoJogador = tipoJogador;
            info.Num = numeroSecreto;
            info.Dificuldade = dif;
            return info;
        }

        private TipoJogador SelecionarJogador()
        {
            Random random = new Random();
            int numero = random.Next(1, 3);

            if (numero == 1)
            {
                return TipoJogador.Jogador;
            }
            else
            {
                return TipoJogador.Maquina;
            }
        }

        private int GerarNumeroSecreto()
        {
            Random random = new Random();
            int numero = random.Next(1, 100);

            return numero;
        }

        public async Task<bool> NovoHistorico(Historico historico)
        {
            historico.Tentativa = DateTime.Now;
            await _contexto.Historicos.AddAsync(historico);
            await _contexto.SaveChangesAsync();

            return true;
        }

        public List<Historico> CarregarHistorico()
        {
            var historico = _contexto.Historicos.ToListAsync();

            return historico.Result.ToList();
        }

        public async Task<Historico> HistoricoDetalhado(Historico historico)
        {
            var stats = await _contexto.Historicos
                .Where(h => h.Tentativa == historico.Tentativa && h.RESULTADO == historico.RESULTADO && h.COD_JOGADOR == historico.COD_JOGADOR && h.NUM_TENTATIVA == historico.NUM_TENTATIVA)
                .FirstOrDefaultAsync();

            return stats;
        }

        public IActionResult DetalhesHistorico()
        {
            return View();
        }

        public Estatistica CarregarEstatistica()
        {
            var historico = new List<Historico>();
            historico = CarregarHistorico();

            var vitoria = 0;
            var derrotas = 0;
            double conta = 0;

            foreach (var i in historico)
            {
                if(i.RESULTADO == "sucesso")
                {
                    vitoria++;
                }
                else
                {
                    derrotas++;
                }
            }
            conta = (double)vitoria / (double)(vitoria + derrotas);
            conta = conta * 100;

            var stats = new Estatistica();
            stats.Vitoria = vitoria;
            stats.Derrota = derrotas;
            stats.Aproveitamento = conta;
            stats.Rank = 1;

            return stats;
        }
    }
}