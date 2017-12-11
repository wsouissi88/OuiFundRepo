using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Domain.Model
{
    public class QuestionReponse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }
        public int ReponseSelected { get; set; }
        public string ReponseString{ get; set; }
        public int QuestionnaireID { get; set; }
        public virtual Questionnaire Questionnaire { get; set; }
    }
}
