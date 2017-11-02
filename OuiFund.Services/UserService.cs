using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OuiFund.Domain;
using OuiFund.Domain.Repositories;
using OuiFund.Domain.Model;

namespace OuiFund.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository { get; set; }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Create(User user)
        {
            _userRepository.Create(user);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll().ToList();
        }
    }
}
