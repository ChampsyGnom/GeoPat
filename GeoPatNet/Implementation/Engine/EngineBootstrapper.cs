﻿using Emash.GeoPatNet.Engine.Infrastructure.ViewModels;
using Emash.GeoPatNet.Engine.Infrastructure.Views;
using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;
using System.Diagnostics;

using Emash.GeoPatNet.Data.Infrastructure.Services;

using Emash.GeoPatNet.Presentation.Infrastructure.Services;
using Microsoft.Practices.Prism.Regions;
using Xceed.Wpf.AvalonDock;
using Microsoft.Practices.ServiceLocation;
using Emash.GeoPatNet.Presentation.Infrastructure.RegionAdapters;
using Xceed.Wpf.AvalonDock.Layout;
using Emash.GeoPatNet.Atom.Infrastructure.Services;
using Emash.GeoPatNet.Engine.Implentation.ViewModels;


namespace Emash.GeoPatNet.Engine.Implementation
{
    public class EngineBootstrapper<VM, V> : UnityBootstrapper
        where VM : IMainViewModel 
        where V : Window,IMainView
       
    {
        public int MaxIntializeTimeout { get; protected set; }
        private Task _moduleInitializerTask;
        public EngineBootstrapper()
        {
            this.MaxIntializeTimeout = 200;
        }
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            this.ModuleCatalog = new DirectoryModuleCatalog() { ModulePath = System.IO.Path.Combine(appStartPath, "Resources\\Modules") };
           
            
        }
        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();
            if (mappings == null) return null;

            // Add custom mappings
            mappings.RegisterMapping(typeof(DockingManager), ServiceLocator.Current.GetInstance<DockingManagerRegionAdapter>());
            mappings.RegisterMapping(typeof(LayoutAnchorable), ServiceLocator.Current.GetInstance<AnchorableRegionAdapter>());
            return mappings;

        }
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            this.Container.RegisterType<IMainViewModel, VM>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IMainView,V>(new ContainerControlledLifetimeManager ());
            this.Container.RegisterType<IDataImportViewModel, DataImportViewModel>();


            
        }


        protected override void InitializeShell()
        {
            base.InitializeShell();
            System.Windows.Application.Current.MainWindow = this.Container.Resolve<V>();
            
        }


        protected override System.Windows.DependencyObject CreateShell()
        {
            V mainView = this.Container.Resolve<V>();
            return mainView;
        }

        protected override void InitializeModules()
        {
           
            base.InitializeModules();
            this.Container.Resolve<ISplashService>().ShowSplash(MaxIntializeTimeout);
            IDataService dataService = this.Container.TryResolve<IDataService>();
            IReperageService reperageService = this.Container.TryResolve<IReperageService>();
            IDashboardService dashBoardService = this.Container.TryResolve<IDashboardService>();            
            if (dataService != null)
            {
                _moduleInitializerTask = new Task(new Action(delegate()
                {
                    dataService.Initialize("HOST=192.168.0.12;PORT=5432;DATABASE=test;USER ID=postgres;PASSWORD=postgres;PRELOADREADER=true;");
                    if (dashBoardService != null)
                    { dashBoardService.Initialize(); }

                    if (reperageService != null)
                    { reperageService.Initialize(); }


                    this.Container.Resolve<ISplashService>().CloseSplash(this.Container.Resolve<V>().Show);
                }));
                _moduleInitializerTask.Start();
              
            }
           
            
        }
    }
}
