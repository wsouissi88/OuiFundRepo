using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OuiFund.Domain.Repositories;
using OuiFund.Domain.Model;
using System.Data.Entity;

namespace OuiFund.Data
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(OuiFundContext context) : base(context)
        {  

        }
        public User GetByCodeAndPassword(string email, string password)
        {

            return Context.Users.FirstOrDefault(b => b.AdresseEmail == email && b.Password == password);

        }
    }
}
