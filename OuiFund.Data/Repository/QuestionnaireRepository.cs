using OuiFund.Domain.Model;
using OuiFund.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Data.Repository
{
    public class QuestionnaireRepository : BaseRepository<Questionnaire>, IQuestionnaireReposittory
    {
        public QuestionnaireRepository(OuiFundContext context) : base(context)
        {
        }

        public Questionnaire getLastQuestionnaireByUserId(int userId)
        {
            return Context.Questionnaires.FirstOrDefault(b => b.UserId == userId);
        }

        public List<Questionnaire> getQuestionnaireByUserId(int userId)
        {
            return Context.Questionnaires.Where(b => b.UserId == userId).ToList();
        }
    }
}
