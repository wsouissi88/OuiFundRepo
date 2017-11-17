using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Data.Configuration
{
    public class AnalyseConfiguration : EntityTypeConfiguration<Analyse>
    {
        public AnalyseConfiguration()
        {
            ToTable("Analyse");
            HasRequired(a => a.Utilisateur).WithMany(q => q.Analyses).HasForeignKey(q => q.UtilisateurId);
            HasRequired(a => a.Question).WithMany(a => a.AnalysesQ).HasForeignKey(q => q.QuestionId);
            HasRequired(a => a.Reponse).WithMany(a => a.AnalysesR).HasForeignKey(q => q.ReponseId);
        }
    }
}
