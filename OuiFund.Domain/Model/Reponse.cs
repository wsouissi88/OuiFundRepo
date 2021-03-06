﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Domain.Model
{
    public class Reponse
    {
        public Reponse()
        {
            this.AnalysesR = new HashSet<Analyse>();                
        }

        [Key]
        public int ReponseID { get; set; }

        [Required]
        [Display(Name = "Réponse")]
        public string TextReponse { get; set; }

        [Display(Name = "Valeur réponse")]
        public int ValeurReponse { get; set; }

        [Display(Name = "Analyse réponse")]
        public string AnalyseReponsePointsForts { get; set; }
        public string AnalyseReponsePointsFaibles { get; set; }
        public string AnalyseReponsePointsaAmeliorer{ get; set; }
        public int questionId { get; set; }
        public virtual Question reponseQuestion { get; set; }

        public virtual ICollection<Analyse> AnalysesR { get; set; }
    }
}
