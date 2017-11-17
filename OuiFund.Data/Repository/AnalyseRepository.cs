using OuiFund.Domain.Model;
using OuiFund.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Data.Repository
{
    public class AnalyseRepository : BaseRepository<Analyse>, IAnalyseRepository
    {
        public AnalyseRepository(OuiFundContext context) : base(context)
        {
        }
    }
}
