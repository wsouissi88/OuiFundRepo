using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Domain.Model
{
    public class CategorieQuest
    {
        public CategorieQuest()
        {
            this.QuestionsCateg = new HashSet<Question>();
        }
        [Key]
        public int CategorieID { get; set; }

        [Required]
        [Display(Name = "Catégorie")]
        public string NomCategorie { get; set; }

        public virtual ICollection<Question> QuestionsCateg { get; set; }
    }
}
