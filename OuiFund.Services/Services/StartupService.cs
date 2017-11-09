using OuiFund.Domain.Repositories;
using OuiFund.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OuiFund.Domain.Model;

namespace OuiFund.Services.Services
{
    public class StartupService : IStartupService
    {
        private IStartupRepository startuprepository { get; set; }

        public StartupService(IStartupRepository startRepo)
        {
            startuprepository = startRepo;
        }

        public void ajouterStartup(StartUp startup)
        {
            startuprepository.Create(startup);
        }

        public StartUp getStartupById(int id)
        {
            return startuprepository.GetById(id);
        }
    }
}
