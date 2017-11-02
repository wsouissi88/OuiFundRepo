using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Data.Configuration
{
    public class CategorieConfiguration : EntityTypeConfiguration<CategorieQuest>
    {
        public CategorieConfiguration()
        {
            ToTable("Categorie");
        }
    }
}
