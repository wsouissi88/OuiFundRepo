using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Services.IServices
{
    public interface IQuestionService
    {
        bool ajouterQuestion(Question question);
        List<Question> getListQuestions();
        List<Question> getQuestionsByType(TypeQuestion type);
        List<Question> RandomQuestions(TypeQuestion type, int count);
        void modifierQuestion(Question question);
        bool supprimerQuestion(int idQuestion);
    }
}
