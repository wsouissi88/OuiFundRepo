using OuiFund.Domain;
using System.Data.Entity;


namespace OuiFund.Data
{
    public class OuiFundContext : DbContext
    {
        public OuiFundContext() : base("OuiFund")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
