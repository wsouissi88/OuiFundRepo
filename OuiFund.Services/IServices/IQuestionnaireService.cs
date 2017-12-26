using OuiFund.Domain;
using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Services.IServices
{
    public interface IQuestionnaireService
    {
        List<Questionnaire> getAll();
        Questionnaire getQuestionnaireById(int questionnaireId);
        List<Questionnaire> getQuestionnaireByUserId(int userId);
        Questionnaire getLastQuestionnaireByUserId(int userId);
        void Create(Questionnaire questionnaire);
        void Update(Questionnaire questionnaire);
        void DeleteQuestionReponseByQuestionnaireId(int questionnaireId);
    }
}
