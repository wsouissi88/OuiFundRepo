using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Domain.Model
{
    public class Question
    {
        public Question()
        {
            this.Reponses = new HashSet<Reponse>();
            this.AnalysesQ = new HashSet<Analyse>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionID { get; set; }

        [Required]
        [Display(Name = "Votre Question")]
        public string DescriptionQuest { get; set; }

        [Display(Name = "Référence")]
        public string ReferenceQuest { get; set; }

        [Display(Name = "Type de question")]
        public TypeQuestion TypeQuest { get; set; }

        [Display(Name = "Status")]
        public bool StatusQuest { get; set; }

        public virtual ICollection<Reponse> Reponses { get; set; }

        public int categorieId { get; set; }
        public virtual CategorieQuest categorieQuestion { get; set; }

        public virtual ICollection<Analyse> AnalysesQ { get; set; }
    }

    public enum TypeQuestion
    {
        TextBoxQuestion=1,
        RadioQuestion=2,
        DdlQuestion=3,
        NoteQuestion = 4,
        TextAreaQUestion = 5
    }
}
