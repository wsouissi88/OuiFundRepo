using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OuiFund.Infrastructure.Security
{
    public class SecurityHelper
    {
        public static bool IsAuthorized(int idAutorisation)
        {
            var currentUserRoleId = GetCurrentUserRoleId();
            return currentUserRoleId == 1;
        }

        public static int GetCurrentUserId()
        {
            if (HttpContext.Current == null) return 0;
            var identity = HttpContext.Current.User as CustomPrincipal;

            return identity == null ? 0 : identity.UserId;
        }

        public static int GetCurrentUserRoleId()
        {
            if (HttpContext.Current == null) return 0;
            var identity = HttpContext.Current.User as CustomPrincipal;

            return identity == null ? 0 : identity.RoleId;
        }

        
    }
}