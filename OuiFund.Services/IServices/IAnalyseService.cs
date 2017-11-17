using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Services.IServices
{
    public interface IAnalyseService
    {
        void saveAnalyse(Analyse analyse);
        List<Analyse> getAnalyseQCMByUser(int userId);
        List<Analyse> getResultAnalyseByUser(int userId);
        List<Analyse> getAnalyseRedactionByUser(int userId);
        void supprimerAnalyse(int analyseId);
    }
}
