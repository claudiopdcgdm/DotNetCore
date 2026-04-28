using Microsoft.EntityFrameworkCore;
using Proeventos.Domain;

namespace Proeventos.Persistence
{
    public class ProeventosContext:DbContext
    {
        public ProeventosContext(DbContextOptions<ProeventosContext> options):base(options)
        {
            
        }

        public  DbSet<Evento> Eventos { get; set; }
        public  DbSet<Lote> Lotes { get; set; }
        public  DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public  DbSet<Palestrante> Palestrante { get; set; }
        public  DbSet<RedeSocial> RedesSocias { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cria o relacionamento de n x n entre Evento e Palestrante
            modelBuilder.Entity<PalestranteEvento>().HasKey(pe => new {pe.EventoId,pe.PalestranteId});

            // OnDeleteCascade para remover todas as redessociais quando o evento for excluído (Tab redeSocial possui chave multipla)
            modelBuilder.Entity<Evento>().HasMany(e => e.RedesSociais).WithOne(rs => rs.Evento).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>().HasMany(p => p.RedesSociais).WithOne(rs => rs.Palestrante).OnDelete(DeleteBehavior.Cascade);
            // modelBuilder.Entity<Palestrante>().HasMany(p => p.RedesSociais).WithOne(rs => rs.Palestrante).OnDeleteCascade();
        }
        
        
    }
}