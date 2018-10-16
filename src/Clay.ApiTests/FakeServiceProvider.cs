using System;
using System.Collections.Generic;

namespace Clay.WebApi.UnitTests
{
    internal class FakeServiceProvider : IServiceProvider
    {
        private readonly IDictionary<Type, object> _services = new Dictionary<Type, object>();

        public void RegisterService<TService>(object impl) =>
            _services.Add(typeof(TService), impl);

        public object GetService(Type serviceType) => _services[serviceType];
    }
}