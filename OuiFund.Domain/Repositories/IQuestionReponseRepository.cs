﻿using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Domain.Repositories
{
    public interface IQuestionReponseRepository : IBaseRepository<QuestionReponse>
    {
        void DeleteQuestionReponseByQuestionnaireId(int questionnaireId);
    }
}
