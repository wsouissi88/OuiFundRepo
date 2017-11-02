using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Data.Configuration
{
    public class ClientConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientConfiguration()
        {
            ToTable("Client");
            HasKey(c => c.UtilisateurID);
            Property(c => c.UtilisateurID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
