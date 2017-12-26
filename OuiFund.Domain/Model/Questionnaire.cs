using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Domain.Model
{
    public class Questionnaire
    {
        public Questionnaire()
        {
            this.Questions = new HashSet<QuestionReponse>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionnaireID { get; set; }
        public DateTime DateCreation { get; set; }
        public virtual ICollection<QuestionReponse> Questions { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public QuestionnaireType Questionnairetype { get; set; }
        public string AnalysePointForts { get; set; }
        public string AnalysePointFaibles { get; set; }
        public string AnalysePointaAmrliorer { get; set; }

    }

    public enum QuestionnaireType
    {
        FirstQuestionnaire = 1,
        SecondQuestionnaire  = 2
    }
}
