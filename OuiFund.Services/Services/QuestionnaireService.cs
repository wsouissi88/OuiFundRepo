using OuiFund.Domain.Model;
using OuiFund.Domain.Repositories;
using OuiFund.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OuiFund.Services.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private IQuestionnaireReposittory _questionnaireReposittory { get; set; }
        private IQuestionReponseRepository _questionReponseReposittory { get; set; }
        public QuestionnaireService(IQuestionnaireReposittory questionnaireReposittory, IQuestionReponseRepository questionReponseReposittory)
        {
            _questionnaireReposittory = questionnaireReposittory;
            _questionReponseReposittory = questionReponseReposittory;
        }

        public Questionnaire getQuestionnaireById(int questionnaireId)
        {
            return _questionnaireReposittory.GetById(questionnaireId);
        }

        public List<Questionnaire> getQuestionnaireByUserId(int userId)
        {
            return _questionnaireReposittory.getQuestionnaireByUserId(userId);
        }

        public Questionnaire getLastQuestionnaireByUserId(int userId)
        {
            return _questionnaireReposittory.getLastQuestionnaireByUserId(userId);
        }

        public void Create(Questionnaire questionnaire)
        {
             _questionnaireReposittory.Create(questionnaire);
        }

        public void Update(Questionnaire questionnaire)
        {
            _questionnaireReposittory.Update(questionnaire);
        }

        public void DeleteQuestionReponseByQuestionnaireId(int questionnaireId)
        {
            _questionReponseReposittory.DeleteQuestionReponseByQuestionnaireId(questionnaireId);
        }
    }
}
