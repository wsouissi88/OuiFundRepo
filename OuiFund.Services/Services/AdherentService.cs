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
    public class AdherentService : IAdherentService
    {
        private IAdherentRepository adherentRepository { get; set; }

        public AdherentService(IAdherentRepository adherentRepo)
        {
            adherentRepository = adherentRepo;
        }

        public void registerAdherent(Adherent a)
        {
            adherentRepository.Create(a);
        }

        public void supprimerAdherent(int id)
        {
            Adherent a = adherentRepository.GetById(id);
            adherentRepository.Delete(a);
        }

        public void updateProfileAdherent(Adherent a)
        {
            adherentRepository.Update(a);
        }
    }
}
