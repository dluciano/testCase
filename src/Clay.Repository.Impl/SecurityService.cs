using Clay.DAL;
using Clay.WebApi;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Principal;
using System.Threading;

namespace Clay.Core.Implementations
{
    public class SecurityService : ISecurityService
    {
        private IRepository<Property> _propertiesRepo
        {
            get => serviceProvider.GetService<IRepository<Property>>();
        }

        private readonly IServiceProvider serviceProvider;

        public SecurityService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

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
        private IIdentity _userId { get => Thread.CurrentPrincipal.Identity; }

        public IQueryable<Property> UserProperties()
        {
            if (Thread.CurrentPrincipal == null || Thread.CurrentPrincipal.Identity == null
                       || !Thread.CurrentPrincipal.Identity.IsAuthenticated)
                return null;
            return _propertiesRepo.Where(p => p.OwnerUsername == _userId.Name);
        }
    }
}
