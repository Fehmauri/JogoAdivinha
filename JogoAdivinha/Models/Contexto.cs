using Microsoft.EntityFrameworkCore;

namespace JogoAdivinha.Models
{
    public class Contexto : DbContext
    {

        public DbSet<Historico> Historicos { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes): base(opcoes)
        {

        }
    }
}
