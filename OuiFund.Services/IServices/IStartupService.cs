﻿using OuiFund.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Services.IServices
{
    public interface IStartupService
    {
        void ajouterStartup(StartUp startup);
        StartUp getStartupById(int id);
    }
}
