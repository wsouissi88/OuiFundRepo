using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Domain.Model
{
    public class Dossier
    {
        public Dossier()
        {
            this.DocumentsDossier = new HashSet<Document>();
        }
        [Key]
        public int DossierID { get; set; }

        [Required]
        [Display(Name = "Status dossier")]
        public string StatusDossier { get; set; }

        [Required]
        [Display(Name = "Référence dossier")]
        public string ReferenceDossier { get; set; }

        public int adherentId { get; set; }
        public virtual Adherent adherentDossier { get; set; }

        public int startupId { get; set; }
        public virtual StartUp startupDossier { get; set; }

        public virtual ICollection<Document> DocumentsDossier { get; set; }
    }
}
