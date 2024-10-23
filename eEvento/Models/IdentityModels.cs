using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eEvento.Models
{
    // É possível adicionar dados do perfil do usuário adicionando mais propriedades na sua classe ApplicationUser, visite https://go.microsoft.com/fwlink/?LinkID=317594 para obter mais informações.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Observe que a authenticationType deve corresponder a uma definida em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Adicionar declarações do usuário personalizadas aqui
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("eEventoDb", throwIfV1Schema: false)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
        public DbSet<Organizador> Organizadores { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Patrocinador> Patrocinadores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações de relacionamentos muitos para muitos
            modelBuilder.Entity<Evento>()
                .HasMany(e => e.Patrocinadores)
                .WithMany(p => p.Eventos)
                .Map(m =>
                {
                    m.ToTable("EventoPatrocinador");
                    m.MapLeftKey("EventoId");
                    m.MapRightKey("PatrocinadorId");
                });

            /* remove o plural dos models*/
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}