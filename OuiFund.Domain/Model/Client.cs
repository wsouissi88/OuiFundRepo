using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Domain.Model
{
    public class Client : Adherent
    {
        public string NiveauEtude { get; set; }

        public int AnneeExperience { get; set; }

    }
}
