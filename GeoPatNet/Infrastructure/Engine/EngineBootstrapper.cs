using Emash.GeoPatNet.Engine.Infrastructure.ViewModels;
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


namespace Emash.GeoPatNet.Engine.Infrastructure
{
    public class EngineBootstrapper<VM, V> : UnityBootstrapper
        where VM : IMainViewModel 
        where V : Window,IMainView
       
    {
        public int MaxIntializeTimeout { get; protected set; }
        private Task _moduleInitializerTask;
        public EngineBootstrapper()
        {
            this.MaxIntializeTimeout = 1000;
        }
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            this.ModuleCatalog = new DirectoryModuleCatalog() { ModulePath = System.IO.Path.Combine(appStartPath, "Resources\\Modules") };
           
            
        }
       
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            this.Container.RegisterType<IMainViewModel, VM>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IMainView,V>(new ContainerControlledLifetimeManager ());
            
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
            if (dataService != null)
            {
                _moduleInitializerTask = new Task(new Action(delegate()
                {
                    dataService.Initialize("HOST=127.0.0.1;PORT=5432;DATABASE=test;USER ID=postgres;PASSWORD=Emash21;PRELOADREADER=true;");
                    this.Container.Resolve<ISplashService>().CloseSplash(this.Container.Resolve<V>().Show);
                }));
                _moduleInitializerTask.Start();
              
            }
        }
    }
}
