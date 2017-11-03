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
    public class CategorieService : ICategorieService
    {
        private ICategorieRepository categRepository { get; set; }

        public CategorieService(ICategorieRepository categRepo)
        {
            categRepository = categRepo;
        }

        public List<CategorieQuest> getCategories()
        {
            var categs = categRepository.GetAll().ToList();
            return categs;
        }

        public CategorieQuest getCategorieById(int idcateg)
        {
            return categRepository.GetById(idcateg);
        }

        public bool ajouterCategorie(CategorieQuest categorie)
        {
            if (categorie != null)
            {
                categRepository.Create(categorie);
                return true;
            }
            else { return false; }
        }

        public void supprimerCategorie(CategorieQuest categ)
        {
            categRepository.Delete(categ);
        }
    }
}
