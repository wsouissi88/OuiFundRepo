using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Data.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Utilisateur");
            //Map<Client>(b => b.Requires("IsType").HasValue("Client"));
            //Map<Adherent>(c => c.Requires("IsType").HasValue("Adherent"));
        }
    }
}
