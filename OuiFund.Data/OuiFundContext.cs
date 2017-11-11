using OuiFund.Data.Configuration;
using OuiFund.Domain;
using OuiFund.Domain.Model;
using System.Data.Entity;


namespace OuiFund.Data
{
    public class OuiFundContext : DbContext
    {
        public OuiFundContext() : base("OuiFund")
        {
            Database.SetInitializer<OuiFundContext>(null);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Adherent> Adherents { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<CategorieQuest> Categories { get; set; }
        public DbSet<Reponse> Reponses { get; set; }
        public DbSet<Dossier> Dossiers { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<StartUp> StartUps { get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new AdherentConfiguration());
            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new CategorieConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new ReponseConfiguration());
            modelBuilder.Configurations.Add(new StartupConfiguration());
            modelBuilder.Configurations.Add(new DossierConfiguration());
            modelBuilder.Configurations.Add(new DocumentConfiguration());


        }
    }
}
