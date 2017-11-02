using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Data.Configuration
{
    public class ReponseConfiguration : EntityTypeConfiguration<Reponse>
    {
        public ReponseConfiguration()
        {
            ToTable("Reponse");
            HasRequired(q => q.reponseQuestion).WithMany(q => q.Reponses).HasForeignKey(q => q.questionId);
        }
    }
}
