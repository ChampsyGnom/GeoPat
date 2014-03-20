using Emash.GeoPatNet.Data.Implementation.Services;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Events;
using Emash.GeoPatNet.Infrastructure.Services;


namespace Emash.GeoPatNet.Data
{
    /// <summary>
    /// Module de gestion des données la DAL en gros
    /// </summary>
    [Module(ModuleName = "Data")]
    public class DataModule : IModule
    {
        private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="eventAggregator">IEventAggregator Prism</param>
        /// <param name="container">IUnityContainer Prism</param>
        public DataModule(IEventAggregator eventAggregator,IUnityContainer container)
        {
            this._eventAggregator = eventAggregator;            
            this._container = container;
        }
        /// <summary>
        /// On enregistre le service de donnée
        /// </summary>
        public void Initialize()
        {

            this._eventAggregator.GetEvent<SplashEvent>().Publish("Initialisation du module de données ...");
            this._container.RegisterType<IDataService, DataService>(new ContainerControlledLifetimeManager());
        }
    }
}
