using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Domain.Repositories
{
    public interface IAdherentRepository : IBaseRepository<Adherent>
    {
        Adherent getAccessAdherent(string login, string password);
    }
}
