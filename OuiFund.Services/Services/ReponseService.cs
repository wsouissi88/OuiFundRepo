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
    public class ReponseService : IReponseService
    {
        private IReponseRepository repoRepository { get; set; }
        public ReponseService(IReponseRepository reponseRepo)
        {
            repoRepository = reponseRepo;
        }
        public bool ajouterReponse(Reponse reponse)
        {
            if (reponse != null)
            {
                repoRepository.Create(reponse);
                return true;
            }
            else { return false; }
        }

        public List<Reponse> getListReponses()
        {
            return repoRepository.GetAll().ToList();
        }

        public List<Reponse> getReponsesQuestion(int questionId)
        {
            return repoRepository.GetAll().Where(r => r.questionId == questionId).ToList();
        }

        public void modifierReponse(Reponse question)
        {
            repoRepository.Update(question);
        }

        public bool supprimerReponse(int idReponse)
        {
            Reponse rep = repoRepository.GetById(idReponse);

            if (rep != null)
            {
                repoRepository.Delete(rep);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
