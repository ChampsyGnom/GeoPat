﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Atom.Infrastructure.Services;
using Emash.GeoPatNet.Presentation.Infrastructure.Events;
using Emash.GeoPatNet.Reperage.Implementation.Services;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Emash.GeoPatNet.Reperage.Implementation
{
    [Module(ModuleName = "Reperage")]
    [ModuleDependency("Data")]
    public class ReperageModule : IModule
    {
         private IEventAggregator _eventAggregator;
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public ReperageModule(IEventAggregator eventAggregator, IUnityContainer container, IRegionManager regionManager)
        {
            this._eventAggregator = eventAggregator;
            this._eventAggregator.GetEvent<SplashEvent>().Publish("Chargement du module repérage ...");
            this._eventAggregator = eventAggregator;
            this._container = container;
            this._regionManager = regionManager;
           
           
        }

        public void Initialize()
        {
            this._container.RegisterType<IReperageService,ReperageService>(new ContainerControlledLifetimeManager ());
        }
    }
}