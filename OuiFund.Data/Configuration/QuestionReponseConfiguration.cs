using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Data.Configuration
{
    class QuestionReponseConfiguration : EntityTypeConfiguration<QuestionReponse>
    {
        public QuestionReponseConfiguration()
        {
            ToTable("QuestionReponse");
            HasRequired(q => q.Questionnaire).WithMany(q => q.Questions).HasForeignKey(q => q.QuestionnaireID);
        }
    }
}

