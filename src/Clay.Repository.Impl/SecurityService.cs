using Clay.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Clay.Core.Implementations
{
    public class SecurityService : ISecurityService
    {
        public string LogedUserName
        {
            get
            {
                if (Thread.CurrentPrincipal == null || Thread.CurrentPrincipal.Identity == null
                    || !Thread.CurrentPrincipal.Identity.IsAuthenticated)
                    return string.Empty;
                return Thread.CurrentPrincipal.Identity.Name;
            }
        }
    }
}
