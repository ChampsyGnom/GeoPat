using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Presentation.Implementation.Services;
using Emash.GeoPatNet.Presentation.Infrastructure.Events;
using Emash.GeoPatNet.Presentation.Infrastructure.Services;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace Emash.GeoPatNet.Presentation.Implementation
{
    [Module(ModuleName="Presentation")]
    public class PresentationModule : IModule
    {
        private IEventAggregator _eventAggregator;
        private IUnityContainer _container;

        public PresentationModule(IEventAggregator eventAggregator, IUnityContainer container)
        {
            this._eventAggregator = eventAggregator;
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Chargement du module graphique ...");
            this._container = container;
            this._container.RegisterType<ISplashService, SplashService>(new ContainerControlledLifetimeManager());
            
        }
        public void Initialize()
        {
            
        }
    }
}
