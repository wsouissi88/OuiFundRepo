using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Domain.Model
{
    public class StartUp
    {
        [Key]
        public int StartupID { get; set; }

        [Required]
        [Display(Name = "StartUp")]
        public string NomStartup { get; set; }

        [Display(Name = "Lieu startup")]
        public string AdresseStartup { get; set; }

        [Display(Name = "Ville")]
        public string VilleStartup { get; set; }

        [Display(Name = "Code postale")]
        public string CodePostale { get; set; }

        [Display(Name = "Tél Startup")]
        public string TelStartup { get; set; }

        [Display(Name = "Date création")]
        public DateTime CreationStartup { get; set; }

        public int dossierId { get; set; }
        public virtual Dossier dossierStartup { get; set; }
    }
}
