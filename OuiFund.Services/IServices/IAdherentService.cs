using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Services.IServices
{
    public interface IAdherentService
    {
        void registerAdherent(Adherent a);
        void updateProfileAdherent(Adherent a);
        void supprimerAdherent(int id);
    }
}
