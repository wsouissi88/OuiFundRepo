using OuiFund.Domain.Model;
using OuiFund.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Data.Repository
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(DbContext context) : base(context)
        {
        }
    }
}
