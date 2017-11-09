using OuiFund.Domain.Repositories;
using OuiFund.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OuiFund.Domain.Model;

namespace OuiFund.Services.Services
{
    public class DossierService : IDossierService
    {
        private IDossierRepository dossierRepository { get; set; }

        public DossierService (IDossierRepository dossRepo)
        {
            dossierRepository = dossRepo;
        }

        public void ajouterDossier(Dossier dossier)
        {
            dossierRepository.Create(dossier);
        }

        public Dossier getDossierById(int id)
        {
            return dossierRepository.GetById(id);
        }
    }
}
