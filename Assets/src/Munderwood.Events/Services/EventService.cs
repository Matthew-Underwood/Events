using Munderwood.Di.Bind;
using Munderwood.Di.Bind.Builder;
using Munderwood.Di.Service;

namespace Munderwood.Events.Services
{
    public class EventService : IService
    {
        public void Service(ServiceLocator serviceLocator)
        {
        }

        public void Bindings(BindBuilder bindBuilder)
        {
            bindBuilder.Bind<EventSystemFactory>().Build().FromMethod(CreateEventSystemFactory).NonLazy();
            bindBuilder.Bind<EventManagerFactory>().Build().FromMethod(CreateEventSystemFactory);
            bindBuilder.Bind<PointerDataEventManagerFactory>().Build().FromMethod(CreateEventSystemFactory);
        }

        private EventSystemFactory CreateEventSystemFactory(IBindContext bindContext)
        {
            var factory = new EventSystemFactory();
            factory.Create();
            return factory;
        }

        private EventManagerFactory CreateEventManagerFactory(IBindContext bindContext)
        {
            return new EventManagerFactory();
        }

        private PointerDataEventManagerFactory CreatePointerDataEventManagerFactory(IBindContext bindContext)
        {
            return new PointerDataEventManagerFactory();
        }
    }
}