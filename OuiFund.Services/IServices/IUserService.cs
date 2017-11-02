using OuiFund.Domain;
using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Services.IServices
{
    public interface IUserService
    {
        User getUserById(int iduser);
        void Create(User user);
        List<User> GetAll();
        int countUsers();
        int countClients();
        int countAdherents();
        int countActive();
        void supprimerUser(User user);
    }
}
