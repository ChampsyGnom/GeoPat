using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Events;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Modules.Document.Services;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Emash.GeoPatNet.Modules.Document
{
    public class DocumentModule : IModule
    {
        private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public DocumentModule(IEventAggregator eventAggregator, IUnityContainer container, IRegionManager regionManager)
        {
            this._eventAggregator = eventAggregator;
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Chargement du module document ...");
            this._eventAggregator = eventAggregator;
            this._container = container;
            this._regionManager = regionManager;
            this._container.RegisterType<IDocumentService, DocumentService>(new ContainerControlledLifetimeManager());

           
        }

        public void Initialize()
        {
           
        }
    }
}
