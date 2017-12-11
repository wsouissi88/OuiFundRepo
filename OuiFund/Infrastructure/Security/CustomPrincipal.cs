using System;
using System.Security.Principal;
using System.Web.Security;

namespace OuiFund.Infrastructure.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private readonly FormsIdentity _identity;
        private int _userId;
        private int _roleId;
        private string[] _userData;

        public CustomPrincipal(FormsIdentity identity)
        {
            _identity = identity;
        }

        public int UserId
        {
            get
            {
                InitUserData();
                return _userId;
            }
        }

        public int RoleId
        {
            get
            {
                InitUserData();
                return _roleId;
            }
        }

        private void InitUserData()
        {
            if (_userData != null) return;
            _userData = _identity.Ticket.UserData.Split(',');
            _roleId = Convert.ToInt32(_userData[0]);
            _userId = Convert.ToInt32(_userData[1]);

        }

        #region ICustomPrincipal Members
        public bool IsInRole(string role)
        {
            return true;
        }

        public IIdentity Identity
        {
            get { return _identity; }
        }
        #endregion
    }
}