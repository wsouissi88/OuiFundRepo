using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Services.IServices
{
    public interface IDossierService
    {
        void ajouterDossier(Dossier dossier);
        Dossier getDossierById(int id);
    }
}
