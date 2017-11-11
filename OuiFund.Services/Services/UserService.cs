using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OuiFund.Domain;
using OuiFund.Domain.Repositories;
using OuiFund.Domain.Model;
using OuiFund.Services.IServices;
using OuiFund.Data;

namespace OuiFund.Services.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository { get; set; }
        private IAdherentRepository _adherentRepository { get; set; }
        private IClientRepository _clientRepository { get; set; }

        public UserService(IUserRepository userRepository, IAdherentRepository adherentRepository,IClientRepository clientRepository)
        {
            _userRepository = userRepository;
            _adherentRepository = adherentRepository;
            _clientRepository = clientRepository;
        }
        public User getUserById(int iduser)
        {
            return _userRepository.GetById(iduser);
        }

        public User getUserByEmail(string email)
        {
            return _userRepository.GetAll().Where(u => u.AdresseEmail == email).FirstOrDefault();
        }

        public User GetByCodeAndPassword(string email, string password)
        {
            return _userRepository.GetByCodeAndPassword(email, password);
        }

        public void Create(User user)
        {
            _userRepository.Create(user);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll().ToList();
        }
        public int countUsers()
        {
            return _userRepository.GetAll().Count();
        }
        public int countAdherents()
        {
            return _adherentRepository.GetAll().Count();
        }
        public int countClients()
        {
            return _clientRepository.GetAll().Count();
        }
        public int countActive()
        {
            return _userRepository.GetAll().Where(u => u.ActiveUser == true).Count();
        }

        public void supprimerUser(User user)
        {
            _userRepository.Delete(user);
        }
    }
}
