using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OuiFund.Models
{
    public class QuestionnaireVm
    {
        public int QuestionnaireId { get; set; }
        public List<CategorieQuestVm> CategorieQuestions { get; set; }
        public QuestionnaireVm()
        {
           
        }
        public QuestionnaireVm(List<CategorieQuest> categories, Questionnaire questionnaire)
        {
            CategorieQuestions = new List<CategorieQuestVm>();
            foreach (var category in categories)
            {
                var questions = new List<QuestionReponse>();
                foreach (var q in category.QuestionsCateg)
                {
                    var questionReponse = new QuestionReponse { Question = q };
                    if (questionnaire != null && questionnaire.QuestionnaireID >0)
                    {
                        var questionRep = questionnaire.Questions.FirstOrDefault(qr => qr.QuestionID == q.QuestionID);
                        if(questionRep != null)
                        {
                            questionReponse.ReponseSelected = questionRep.ReponseSelected;
                            questionReponse.ReponseString = questionRep.ReponseString;
                        }
                    }
                    questions.Add(questionReponse);
                }
                var categorieQuestVm = new CategorieQuestVm
                {
                    CategorieQuest = category,
                    Questions = questions
                };
                CategorieQuestions.Add(categorieQuestVm);
            }
        }
      
        
    }

    public class CategorieQuestVm
    {
        public CategorieQuest CategorieQuest { get; set; }
        public List<QuestionReponse> Questions { get; set; }
        public CategorieQuestVm()
        {

        }
    }
}