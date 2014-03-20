using Emash.GeoPatNet.Infrastructure.ViewModels;
using Emash.GeoPatNet.Infrastructure.Views;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using System.Diagnostics;

using Emash.GeoPatNet.Infrastructure.Services;



using Xceed.Wpf.AvalonDock;
using Microsoft.Practices.ServiceLocation;
using Emash.GeoPatNet.Infrastructure.RegionAdapters;
using Xceed.Wpf.AvalonDock.Layout;

using Emash.GeoPatNet.Engine.ViewModels;
using Emash.GeoPatNet.Engine.Services;



namespace Emash.GeoPatNet.Engine
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
            String modulePath = System.IO.Path.Combine(appStartPath, "Resources\\Modules");
            if (!System.IO.Directory.Exists(modulePath))
            { System.IO.Directory.CreateDirectory(modulePath); }
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
            this.Container.RegisterType<IEngineService, EngineService>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<ITranslateService, TranslateService>(new ContainerControlledLifetimeManager());

            
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
        public virtual void InitializeApplication()
        {
        }
        protected override void InitializeModules()
        {
           
            base.InitializeModules();
            this.Container.Resolve<ISplashService>().ShowSplash(MaxIntializeTimeout);


            IDataService dataService = this.Container.TryResolve<IDataService>();
            IReperageService reperageService = this.Container.TryResolve<IReperageService>();
            IDashboardService dashBoardService = this.Container.TryResolve<IDashboardService>();
            ICartoService cartoService = this.Container.TryResolve<ICartoService>();
            ITranslateService translateService = this.Container.TryResolve<ITranslateService>();
            IDocumentService documentService = this.Container.TryResolve<IDocumentService>();
            if (dataService != null)
            {
               // _moduleInitializerTask = new Task(new Action(delegate()
              //  {
                dataService.Initialize("HOST=192.168.0.12;PORT=5432;DATABASE=test;USER ID=postgres;PASSWORD=postgres;PRELOADREADER=true;");
             
                if (translateService != null)
                { translateService.Initialize(); }

                if (dashBoardService != null)
                { dashBoardService.Initialize(); }

                if (reperageService != null)
                { reperageService.Initialize(); }

                if (cartoService != null)
                { cartoService.Initialize(); }

                if (documentService != null)
                { documentService.Initialize(); }

                this.InitializeApplication();

                this.Container.Resolve<ISplashService>().CloseSplash(null);
                this.Container.Resolve<V>().Show();
              //  }));
              //  _moduleInitializerTask.Start();
                   
              
            }
            
            
        }
    }
}
