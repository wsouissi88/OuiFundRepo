using OuiFund.Domain;
using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Services
{
    public interface IUserService
    {
        void Create(User user);
        List<User> GetAll();
    }
}
