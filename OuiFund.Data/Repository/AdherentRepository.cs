using OuiFund.Domain.Model;
using OuiFund.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Data.Repository
{
    public class AdherentRepository : BaseRepository<Adherent>, IAdherentRepository
    {
        public AdherentRepository(OuiFundContext context) : base(context)
        {
        }
        public Adherent getAccessAdherent(string login, string password)
        {
            return Context.Adherents.FirstOrDefault(a => a.LoginUser == login && a.Password == password);
        }
    }
}
