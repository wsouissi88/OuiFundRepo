using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Domain.Model
{
    public class Analyse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnalyseID { get; set; }

        [Display(Name = "Analyse")]
        public string AnalyseModel { get; set; }

        [Display(Name = "Type")]
        public AnalyseType TypeAnalyse { get; set; }

        public int? QuestionId { get; set; }
        public int? ReponseId { get; set; }

        [Display(Name = "Evaluation")]
        public int NoteQuestion { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string TextQuestion { get; set; }

        [Required]
        public int UtilisateurId { get; set; }
        public virtual User Utilisateur { get; set; }

        public virtual Question Question { get; set; }
        public virtual Reponse Reponse { get; set; }

        public enum AnalyseType
        {
            [Display(Name = "QCM")]
            QCM = 1,
            [Display(Name = "Note")]
            Notee = 2,
            [Display(Name = "Text")]
            Ouvert = 3
        }
    }
}
