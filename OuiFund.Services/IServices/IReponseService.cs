using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Services.IServices
{
    public interface IReponseService
    {
        bool ajouterReponse(Reponse reponse);
        List<Reponse> getListReponses();
        List<Reponse> getReponsesQuestion(int questionId);
        void modifierReponse(Reponse reponse);
        bool supprimerReponse(int idReponse);
    }
}
