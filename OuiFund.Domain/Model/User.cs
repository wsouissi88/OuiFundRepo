using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Domain.Model
{
    public class User
    {
        public User()
        {
            this.Analyses = new HashSet<Analyse>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UtilisateurID { get; set; }

        [Display(Name = "Votre Email")]
        //[DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")]
        [Required(ErrorMessage = "Adresse email obligatoire")]
        public string AdresseEmail { get; set; }
        public string Password { get; set; }

        [Display(Name = "Status (Active)")]
        public bool ActiveUser { get; set; }

        public virtual ICollection<Analyse> Analyses { get; set; }
    }
}
