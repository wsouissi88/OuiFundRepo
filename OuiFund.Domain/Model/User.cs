using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Domain
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UtilisateurID { get; set; }

        [Display(Name = "Votre Email")]
        [DataType(DataType.EmailAddress)]
        //[RegularExpression(@"\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b")]
        [Required(ErrorMessage = "Adresse email obligatoire")]
        public string AdresseEmail { get; set; }

        [Display(Name = "Status (Active)")]
        public bool ActiveUser { get; set; }
    }
}
