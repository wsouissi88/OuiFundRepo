using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Domain.Model
{
    public class Adherent : User
    {
        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Nom obligatoire")]
        public string NomUser { get; set; }

        [Display(Name = "Prénom")]
        public string PrenomUser { get; set; }

        [Display(Name = "Num Tél")]
        [Required(ErrorMessage = "Numéro de Tél obligatoire")]
        [DataType(DataType.PhoneNumber)]
        public string TelUser { get; set; }

        [Display(Name = "Date de Naissance")]
        public DateTime DateNaissance { get; set; }

        [Display(Name = "Identifiant")]
        [Required(ErrorMessage = "Identifiant obligatoire")]
        public string LoginUser { get; set; }

        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Mot de passe obligatoire")]
        public string PasswordUser { get; set; }

        [Display(Name = "Nom complet")]
        public string NomCompletUser
        {
            get
            {
                return PrenomUser + ", " + NomUser;
            }
        }

        public int dossierId { get; set; }
        public virtual Dossier dossierAdherent { get; set; }
    }
}
