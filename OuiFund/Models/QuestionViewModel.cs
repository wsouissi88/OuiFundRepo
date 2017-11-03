using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OuiFund.Models
{
    public class QuestionViewModel
    {
        public Question question { get; set; }
        public Reponse reponse { get; set; }
    }
}