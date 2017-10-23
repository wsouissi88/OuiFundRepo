using OuiFund.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OuiFund.Models
{
    public class HomeViewModel
    {
        public List<User> Users { get; set; }
        public User User { get; set; }
    }
}