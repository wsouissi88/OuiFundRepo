using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Data.Configuration
{
    public class DossierConfiguration : EntityTypeConfiguration<Dossier>
    {
        public DossierConfiguration()
        {
            ToTable("Dossier");
            HasOptional(s => s.startupDossier).WithRequired(s => s.dossierStartup);
            HasOptional(s => s.adherentDossier).WithRequired(s => s.dossierAdherent);

        }
    }
}
