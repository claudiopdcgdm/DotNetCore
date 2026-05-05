using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proeventos.Domain;
using Proeventos.Domain.Identity;

namespace Proeventos.Persistence
{
    public class ProeventosContext:IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
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
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<UserRole>(UserRole => {
                UserRole.HasKey(ur => new {ur.UserId, ur.RoleId});
                UserRole.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId).IsRequired();
                UserRole.HasOne(ur => ur.User).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.UserId).IsRequired();

            });

            // Cria o relacionamento de n x n entre Evento e Palestrante
            modelBuilder.Entity<PalestranteEvento>().HasKey(pe => new {pe.EventoId,pe.PalestranteId});

            // OnDeleteCascade para remover todas as redessociais relacionadas ao evento quando o evento for excluído (Tab redeSocial possui chave multipla)
            modelBuilder.Entity<Evento>().HasMany(e => e.RedesSociais).WithOne(rs => rs.Evento).OnDelete(DeleteBehavior.Cascade);

            // OnDeleteCascade para remover todas as redessociais relacionadas ao palestrante quando o Palestrante for excluído (Tab redeSocial possui chave multipla)
            modelBuilder.Entity<Palestrante>().HasMany(p => p.RedesSociais).WithOne(rs => rs.Palestrante).OnDelete(DeleteBehavior.Cascade);
           
            // OnDeleteCascade para remover todos os Lotes relacionados ao evento quando o evento for excluído (Tab Lote possui chave multipla)
            modelBuilder.Entity<Evento>().HasMany(e => e.Lotes).WithOne(l => l.Evento).OnDelete(DeleteBehavior.Cascade);
            

            //Normalize name tables
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("TbUsers");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("TbRoles");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("TbUserRoles");
            });

            modelBuilder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("TbUserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("TbUserLogins");
            });

            modelBuilder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("TbRoleClaims");
            });

            modelBuilder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("TbUserTokens");
            });

            
          
           
        }
        
        
    }
}