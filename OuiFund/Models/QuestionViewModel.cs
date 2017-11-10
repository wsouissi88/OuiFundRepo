using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OuiFund.Models
{
    public class QuestionViewModel
    {
        //public Question question { get; set; }

        //public int QuestionID { get; set; }
        
        [Display(Name = "Votre Question")]
        public string DescriptionQuest { get; set; }

        [Display(Name = "Référence")]
        public string ReferenceQuest { get; set; }

        [Display(Name = "Type de question")]
        public TypeQuestion TypeQuest { get; set; }

        [Display(Name = "Status")]
        public bool StatusQuest { get; set; }

        [Display(Name = "Catégorie")]
        public int CategorieID { get; set; }

        [Display(Name ="Réponse:Analyse")]
        public string reponse { get; set; }
    }
}