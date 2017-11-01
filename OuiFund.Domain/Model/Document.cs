using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Domain.Model
{
    public class Document
    {
        [Key]
        public int DocumentID { get; set; }

        [Required]
        [Display(Name = "Titre document")]
        public string TitreDoc { get; set; }

        [Required]
        [Display(Name = "Type document")]
        public string TypeDoc { get; set; }

        public int dossierId { get; set; }
        public virtual Dossier dossierDocument { get; set; }
    }
}
