using OuiFund.Data.Migrations;
using OuiFund.Domain.Model;
using OuiFund.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Data.Repository
{
    public class QuestionReponseRepository : BaseRepository<QuestionReponse>, IQuestionReponseRepository
    {
        public QuestionReponseRepository(OuiFundContext context) : base(context)
        {
        }

        public void DeleteQuestionReponseByQuestionnaireId(int questionnaireId)
        {
            Context.QuestionReponses.RemoveRange(Context.QuestionReponses.Where(x => x.QuestionnaireID == questionnaireId));
            Context.SaveChanges();
        }
    }
}
