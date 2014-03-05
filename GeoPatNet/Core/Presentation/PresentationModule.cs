using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Events;
using Emash.GeoPatNet.Infrastructure.Services;
using Emash.GeoPatNet.Presentation.Services;
using Emash.GeoPatNet.Presentation.Views;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Emash.GeoPatNet.Presentation
{
    [Module(ModuleName="Presentation")]
    public class PresentationModule : IModule
    {
        private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public PresentationModule(IEventAggregator eventAggregator, IUnityContainer container,IRegionManager regionManager)
        {
            this._eventAggregator = eventAggregator;
            this._regionManager = regionManager;
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Chargement du module graphique ...");
            this._container = container;
            this._container.RegisterType<ISplashService, SplashService>(new ContainerControlledLifetimeManager());
            this._container.RegisterType<IDialogService, DialogService>(new ContainerControlledLifetimeManager());
            this._regionManager.RegisterViewWithRegion("DataImportRegion", typeof(DataImportView));

            this._regionManager.RegisterViewWithRegion("CustomFilterRegion", typeof(CustomFilterView));
            this._regionManager.RegisterViewWithRegion("CustomSortRegion", typeof(CustomSortView));
            this._regionManager.RegisterViewWithRegion("CustomDisplayRegion", typeof(CustomDisplayView));
            
        }
        public void Initialize()
        {
            
        }
    }
}
