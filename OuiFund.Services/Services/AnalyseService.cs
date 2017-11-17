using OuiFund.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OuiFund.Domain.Model;
using OuiFund.Domain.Repositories;

namespace OuiFund.Services.Services
{
    public class AnalyseService : IAnalyseService
    {
        private IAnalyseRepository analyseRepository { get; set; }
        List<Analyse> analyses = new List<Analyse>();

        public AnalyseService(IAnalyseRepository analyseRepo)
        {
            analyseRepository = analyseRepo;
        }

        public List<Analyse> getAnalyseQCMByUser(int userId)
        {
            analyses = analyseRepository.GetAll().Where(a => a.UtilisateurId == userId && a.TypeAnalyse == Analyse.AnalyseType.QCM).ToList();
            return analyses;
        }

        public List<Analyse> getAnalyseRedactionByUser(int userId)
        {
            analyses = analyseRepository.GetAll().Where(a => a.UtilisateurId == userId && a.TypeAnalyse == Analyse.AnalyseType.Ouvert).ToList();
            return analyses;
        }

        public List<Analyse> getResultAnalyseByUser(int userId)
        {
            analyses = analyseRepository.GetAll().Where(a => a.UtilisateurId == userId && a.TypeAnalyse == Analyse.AnalyseType.Notee).ToList();
            return analyses;
        }

        public void saveAnalyse(Analyse analyse)
        {
            analyseRepository.Create(analyse);
        }

        public void supprimerAnalyse(int analyseId)
        {
            Analyse a = analyseRepository.GetById(analyseId);
            analyseRepository.Delete(a);
        }
    }
}
